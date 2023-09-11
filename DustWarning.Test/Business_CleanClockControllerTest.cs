using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Business.Business_CleanClockVMs;
using DustWarning.Model.Business;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Business_CleanClockControllerTest
    {
        private Business_CleanClockController _controller;
        private string _seed;

        public Business_CleanClockControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Business_CleanClockController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Business_CleanClockListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Business_CleanClockVM));

            Business_CleanClockVM vm = rv.Model as Business_CleanClockVM;
            Business_CleanClock v = new Business_CleanClock();
			
            v.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
            v.RecordName = "z";
            v.OperateName = "cyid";
            v.Situation = "t7";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_CleanClock>().Find(v.ID);
				
                Assert.AreEqual(data.CleanTime, DateTime.Parse("2023-03-27 14:27:49"));
                Assert.AreEqual(data.RecordName, "z");
                Assert.AreEqual(data.OperateName, "cyid");
                Assert.AreEqual(data.Situation, "t7");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Business_CleanClock v = new Business_CleanClock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
                v.RecordName = "z";
                v.OperateName = "cyid";
                v.Situation = "t7";
                context.Set<Business_CleanClock>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_CleanClockVM));

            Business_CleanClockVM vm = rv.Model as Business_CleanClockVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Business_CleanClock();
            v.ID = vm.Entity.ID;
       		
            v.CleanTime = DateTime.Parse("2024-10-02 14:27:49");
            v.RecordName = "454Ut2ecLph0RTLnz";
            v.OperateName = "PFU2uGhL2Mv1Hr9Vze";
            v.Situation = "p0XsoiM1U5tL";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.CleanTime", "");
            vm.FC.Add("Entity.RecordName", "");
            vm.FC.Add("Entity.OperateName", "");
            vm.FC.Add("Entity.Situation", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_CleanClock>().Find(v.ID);
 				
                Assert.AreEqual(data.CleanTime, DateTime.Parse("2024-10-02 14:27:49"));
                Assert.AreEqual(data.RecordName, "454Ut2ecLph0RTLnz");
                Assert.AreEqual(data.OperateName, "PFU2uGhL2Mv1Hr9Vze");
                Assert.AreEqual(data.Situation, "p0XsoiM1U5tL");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Business_CleanClock v = new Business_CleanClock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
                v.RecordName = "z";
                v.OperateName = "cyid";
                v.Situation = "t7";
                context.Set<Business_CleanClock>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_CleanClockVM));

            Business_CleanClockVM vm = rv.Model as Business_CleanClockVM;
            v = new Business_CleanClock();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_CleanClock>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Business_CleanClock v = new Business_CleanClock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
                v.RecordName = "z";
                v.OperateName = "cyid";
                v.Situation = "t7";
                context.Set<Business_CleanClock>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Business_CleanClock v1 = new Business_CleanClock();
            Business_CleanClock v2 = new Business_CleanClock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
                v1.RecordName = "z";
                v1.OperateName = "cyid";
                v1.Situation = "t7";
                v2.CleanTime = DateTime.Parse("2024-10-02 14:27:49");
                v2.RecordName = "454Ut2ecLph0RTLnz";
                v2.OperateName = "PFU2uGhL2Mv1Hr9Vze";
                v2.Situation = "p0XsoiM1U5tL";
                context.Set<Business_CleanClock>().Add(v1);
                context.Set<Business_CleanClock>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_CleanClockBatchVM));

            Business_CleanClockBatchVM vm = rv.Model as Business_CleanClockBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_CleanClock>().Find(v1.ID);
                var data2 = context.Set<Business_CleanClock>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Business_CleanClock v1 = new Business_CleanClock();
            Business_CleanClock v2 = new Business_CleanClock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CleanTime = DateTime.Parse("2023-03-27 14:27:49");
                v1.RecordName = "z";
                v1.OperateName = "cyid";
                v1.Situation = "t7";
                v2.CleanTime = DateTime.Parse("2024-10-02 14:27:49");
                v2.RecordName = "454Ut2ecLph0RTLnz";
                v2.OperateName = "PFU2uGhL2Mv1Hr9Vze";
                v2.Situation = "p0XsoiM1U5tL";
                context.Set<Business_CleanClock>().Add(v1);
                context.Set<Business_CleanClock>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_CleanClockBatchVM));

            Business_CleanClockBatchVM vm = rv.Model as Business_CleanClockBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_CleanClock>().Find(v1.ID);
                var data2 = context.Set<Business_CleanClock>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Business_CleanClockListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Sys.Sys_DataForwardVMs;
using DustWarning.Model.Sys;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Sys_DataForwardControllerTest
    {
        private Sys_DataForwardController _controller;
        private string _seed;

        public Sys_DataForwardControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Sys_DataForwardController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Sys_DataForwardListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DataForwardVM));

            Sys_DataForwardVM vm = rv.Model as Sys_DataForwardVM;
            Sys_DataForward v = new Sys_DataForward();
			
            v.Name = "F";
            v.FTypeId = AddSys_Dictionary();
            v.Ip = "JX48eSMs";
            v.Port = "PrbUUrVnQUYXmz3i";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_DataForward>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "F");
                Assert.AreEqual(data.Ip, "JX48eSMs");
                Assert.AreEqual(data.Port, "PrbUUrVnQUYXmz3i");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Sys_DataForward v = new Sys_DataForward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "F";
                v.FTypeId = AddSys_Dictionary();
                v.Ip = "JX48eSMs";
                v.Port = "PrbUUrVnQUYXmz3i";
                context.Set<Sys_DataForward>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DataForwardVM));

            Sys_DataForwardVM vm = rv.Model as Sys_DataForwardVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Sys_DataForward();
            v.ID = vm.Entity.ID;
       		
            v.Name = "708cl4PE9ZJgQe2";
            v.Ip = "uEMmG";
            v.Port = "OnLvfnL4AIH";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.FTypeId", "");
            vm.FC.Add("Entity.Ip", "");
            vm.FC.Add("Entity.Port", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_DataForward>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "708cl4PE9ZJgQe2");
                Assert.AreEqual(data.Ip, "uEMmG");
                Assert.AreEqual(data.Port, "OnLvfnL4AIH");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Sys_DataForward v = new Sys_DataForward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "F";
                v.FTypeId = AddSys_Dictionary();
                v.Ip = "JX48eSMs";
                v.Port = "PrbUUrVnQUYXmz3i";
                context.Set<Sys_DataForward>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DataForwardVM));

            Sys_DataForwardVM vm = rv.Model as Sys_DataForwardVM;
            v = new Sys_DataForward();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_DataForward>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Sys_DataForward v = new Sys_DataForward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "F";
                v.FTypeId = AddSys_Dictionary();
                v.Ip = "JX48eSMs";
                v.Port = "PrbUUrVnQUYXmz3i";
                context.Set<Sys_DataForward>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Sys_DataForward v1 = new Sys_DataForward();
            Sys_DataForward v2 = new Sys_DataForward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "F";
                v1.FTypeId = AddSys_Dictionary();
                v1.Ip = "JX48eSMs";
                v1.Port = "PrbUUrVnQUYXmz3i";
                v2.Name = "708cl4PE9ZJgQe2";
                v2.FTypeId = v1.FTypeId; 
                v2.Ip = "uEMmG";
                v2.Port = "OnLvfnL4AIH";
                context.Set<Sys_DataForward>().Add(v1);
                context.Set<Sys_DataForward>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DataForwardBatchVM));

            Sys_DataForwardBatchVM vm = rv.Model as Sys_DataForwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_DataForward>().Find(v1.ID);
                var data2 = context.Set<Sys_DataForward>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Sys_DataForward v1 = new Sys_DataForward();
            Sys_DataForward v2 = new Sys_DataForward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "F";
                v1.FTypeId = AddSys_Dictionary();
                v1.Ip = "JX48eSMs";
                v1.Port = "PrbUUrVnQUYXmz3i";
                v2.Name = "708cl4PE9ZJgQe2";
                v2.FTypeId = v1.FTypeId; 
                v2.Ip = "uEMmG";
                v2.Port = "OnLvfnL4AIH";
                context.Set<Sys_DataForward>().Add(v1);
                context.Set<Sys_DataForward>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DataForwardBatchVM));

            Sys_DataForwardBatchVM vm = rv.Model as Sys_DataForwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_DataForward>().Find(v1.ID);
                var data2 = context.Set<Sys_DataForward>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Sys_DataForwardListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "mMn0JX";
                v.Code = "cKwAD15TuyT1h";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

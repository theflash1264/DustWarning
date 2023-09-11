using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Business.Business_NoticeVMs;
using DustWarning.Model.Business;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Business_NoticeControllerTest
    {
        private Business_NoticeController _controller;
        private string _seed;

        public Business_NoticeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Business_NoticeController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Business_NoticeListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Business_NoticeVM));

            Business_NoticeVM vm = rv.Model as Business_NoticeVM;
            Business_Notice v = new Business_Notice();
			
            v.Title = "4oZZZQQHNf4OqHo";
            v.Content = "hBLHL";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Notice>().Find(v.ID);
				
                Assert.AreEqual(data.Title, "4oZZZQQHNf4OqHo");
                Assert.AreEqual(data.Content, "hBLHL");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Business_Notice v = new Business_Notice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Title = "4oZZZQQHNf4OqHo";
                v.Content = "hBLHL";
                context.Set<Business_Notice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_NoticeVM));

            Business_NoticeVM vm = rv.Model as Business_NoticeVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Business_Notice();
            v.ID = vm.Entity.ID;
       		
            v.Title = "jYMRv2Hfz";
            v.Content = "ZpGD";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.Content", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Notice>().Find(v.ID);
 				
                Assert.AreEqual(data.Title, "jYMRv2Hfz");
                Assert.AreEqual(data.Content, "ZpGD");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Business_Notice v = new Business_Notice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Title = "4oZZZQQHNf4OqHo";
                v.Content = "hBLHL";
                context.Set<Business_Notice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_NoticeVM));

            Business_NoticeVM vm = rv.Model as Business_NoticeVM;
            v = new Business_Notice();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Notice>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Business_Notice v = new Business_Notice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Title = "4oZZZQQHNf4OqHo";
                v.Content = "hBLHL";
                context.Set<Business_Notice>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Business_Notice v1 = new Business_Notice();
            Business_Notice v2 = new Business_Notice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Title = "4oZZZQQHNf4OqHo";
                v1.Content = "hBLHL";
                v2.Title = "jYMRv2Hfz";
                v2.Content = "ZpGD";
                context.Set<Business_Notice>().Add(v1);
                context.Set<Business_Notice>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_NoticeBatchVM));

            Business_NoticeBatchVM vm = rv.Model as Business_NoticeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_Notice>().Find(v1.ID);
                var data2 = context.Set<Business_Notice>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Business_Notice v1 = new Business_Notice();
            Business_Notice v2 = new Business_Notice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Title = "4oZZZQQHNf4OqHo";
                v1.Content = "hBLHL";
                v2.Title = "jYMRv2Hfz";
                v2.Content = "ZpGD";
                context.Set<Business_Notice>().Add(v1);
                context.Set<Business_Notice>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_NoticeBatchVM));

            Business_NoticeBatchVM vm = rv.Model as Business_NoticeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_Notice>().Find(v1.ID);
                var data2 = context.Set<Business_Notice>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Business_NoticeListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}

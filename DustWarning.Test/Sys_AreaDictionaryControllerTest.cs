using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs;
using DustWarning.Model.Sys;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Sys_AreaDictionaryControllerTest
    {
        private Sys_AreaDictionaryController _controller;
        private string _seed;

        public Sys_AreaDictionaryControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Sys_AreaDictionaryController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Sys_AreaDictionaryListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_AreaDictionaryVM));

            Sys_AreaDictionaryVM vm = rv.Model as Sys_AreaDictionaryVM;
            Sys_AreaDictionary v = new Sys_AreaDictionary();
			
            v.Name = "DK33kqHWt6aMAR9EEJ";
            v.AreaCode = "beDu";
            v.ParentId = AddSys_AreaDictionary();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_AreaDictionary>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "DK33kqHWt6aMAR9EEJ");
                Assert.AreEqual(data.AreaCode, "beDu");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "DK33kqHWt6aMAR9EEJ";
                v.AreaCode = "beDu";
                v.ParentId = AddSys_AreaDictionary();
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_AreaDictionaryVM));

            Sys_AreaDictionaryVM vm = rv.Model as Sys_AreaDictionaryVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Sys_AreaDictionary();
            v.ID = vm.Entity.ID;
       		
            v.Name = "oiLRd3f";
            v.AreaCode = "Ie";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.AreaCode", "");
            vm.FC.Add("Entity.ParentId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_AreaDictionary>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "oiLRd3f");
                Assert.AreEqual(data.AreaCode, "Ie");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "DK33kqHWt6aMAR9EEJ";
                v.AreaCode = "beDu";
                v.ParentId = AddSys_AreaDictionary();
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_AreaDictionaryVM));

            Sys_AreaDictionaryVM vm = rv.Model as Sys_AreaDictionaryVM;
            v = new Sys_AreaDictionary();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_AreaDictionary>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "DK33kqHWt6aMAR9EEJ";
                v.AreaCode = "beDu";
                v.ParentId = AddSys_AreaDictionary();
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Sys_AreaDictionary v1 = new Sys_AreaDictionary();
            Sys_AreaDictionary v2 = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "DK33kqHWt6aMAR9EEJ";
                v1.AreaCode = "beDu";
                v1.ParentId = AddSys_AreaDictionary();
                v2.Name = "oiLRd3f";
                v2.AreaCode = "Ie";
                v2.ParentId = v1.ParentId; 
                context.Set<Sys_AreaDictionary>().Add(v1);
                context.Set<Sys_AreaDictionary>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_AreaDictionaryBatchVM));

            Sys_AreaDictionaryBatchVM vm = rv.Model as Sys_AreaDictionaryBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_AreaDictionary>().Find(v1.ID);
                var data2 = context.Set<Sys_AreaDictionary>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Sys_AreaDictionary v1 = new Sys_AreaDictionary();
            Sys_AreaDictionary v2 = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "DK33kqHWt6aMAR9EEJ";
                v1.AreaCode = "beDu";
                v1.ParentId = AddSys_AreaDictionary();
                v2.Name = "oiLRd3f";
                v2.AreaCode = "Ie";
                v2.ParentId = v1.ParentId; 
                context.Set<Sys_AreaDictionary>().Add(v1);
                context.Set<Sys_AreaDictionary>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_AreaDictionaryBatchVM));

            Sys_AreaDictionaryBatchVM vm = rv.Model as Sys_AreaDictionaryBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_AreaDictionary>().Find(v1.ID);
                var data2 = context.Set<Sys_AreaDictionary>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        private Guid AddSys_AreaDictionary()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "L";
                v.AreaCode = "w5ypCHb5m";
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

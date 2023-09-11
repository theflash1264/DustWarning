using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Sys.Sys_DictionaryVMs;
using DustWarning.Model.Sys;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Sys_DictionaryControllerTest
    {
        private Sys_DictionaryController _controller;
        private string _seed;

        public Sys_DictionaryControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Sys_DictionaryController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Sys_DictionaryListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DictionaryVM));

            Sys_DictionaryVM vm = rv.Model as Sys_DictionaryVM;
            Sys_Dictionary v = new Sys_Dictionary();
			
            v.Name = "WDql9DnN";
            v.Code = "FNH9QOr4AIK";
            v.ParentId = AddSys_Dictionary();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_Dictionary>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "WDql9DnN");
                Assert.AreEqual(data.Code, "FNH9QOr4AIK");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "WDql9DnN";
                v.Code = "FNH9QOr4AIK";
                v.ParentId = AddSys_Dictionary();
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DictionaryVM));

            Sys_DictionaryVM vm = rv.Model as Sys_DictionaryVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Sys_Dictionary();
            v.ID = vm.Entity.ID;
       		
            v.Name = "R3Dq";
            v.Code = "1IL9NzvM1r2F9YXF0";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.ParentId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_Dictionary>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "R3Dq");
                Assert.AreEqual(data.Code, "1IL9NzvM1r2F9YXF0");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "WDql9DnN";
                v.Code = "FNH9QOr4AIK";
                v.ParentId = AddSys_Dictionary();
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DictionaryVM));

            Sys_DictionaryVM vm = rv.Model as Sys_DictionaryVM;
            v = new Sys_Dictionary();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Sys_Dictionary>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "WDql9DnN";
                v.Code = "FNH9QOr4AIK";
                v.ParentId = AddSys_Dictionary();
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Sys_Dictionary v1 = new Sys_Dictionary();
            Sys_Dictionary v2 = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "WDql9DnN";
                v1.Code = "FNH9QOr4AIK";
                v1.ParentId = AddSys_Dictionary();
                v2.Name = "R3Dq";
                v2.Code = "1IL9NzvM1r2F9YXF0";
                v2.ParentId = v1.ParentId; 
                context.Set<Sys_Dictionary>().Add(v1);
                context.Set<Sys_Dictionary>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DictionaryBatchVM));

            Sys_DictionaryBatchVM vm = rv.Model as Sys_DictionaryBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_Dictionary>().Find(v1.ID);
                var data2 = context.Set<Sys_Dictionary>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Sys_Dictionary v1 = new Sys_Dictionary();
            Sys_Dictionary v2 = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "WDql9DnN";
                v1.Code = "FNH9QOr4AIK";
                v1.ParentId = AddSys_Dictionary();
                v2.Name = "R3Dq";
                v2.Code = "1IL9NzvM1r2F9YXF0";
                v2.ParentId = v1.ParentId; 
                context.Set<Sys_Dictionary>().Add(v1);
                context.Set<Sys_Dictionary>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Sys_DictionaryBatchVM));

            Sys_DictionaryBatchVM vm = rv.Model as Sys_DictionaryBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Sys_Dictionary>().Find(v1.ID);
                var data2 = context.Set<Sys_Dictionary>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "tLpq7c6PDta4fDgJA4Z";
                v.Code = "RvpKn0sa0n7OSRq0eI";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

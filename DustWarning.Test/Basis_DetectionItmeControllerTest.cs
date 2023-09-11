using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_DetectionItmeVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;
using DustWarning.Model.Sys;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_DetectionItmeControllerTest
    {
        private Basis_DetectionItmeController _controller;
        private string _seed;

        public Basis_DetectionItmeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_DetectionItmeController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_DetectionItmeListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DetectionItmeVM));

            Basis_DetectionItmeVM vm = rv.Model as Basis_DetectionItmeVM;
            Basis_DetectionItme v = new Basis_DetectionItme();
			
            v.Name = "1JcfuZ58";
            v.Code = "sH7OLh8HkvbwVoDoDKR";
            v.UDictionaryId = AddSys_Dictionary();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DetectionItme>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "1JcfuZ58");
                Assert.AreEqual(data.Code, "sH7OLh8HkvbwVoDoDKR");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_DetectionItme v = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "1JcfuZ58";
                v.Code = "sH7OLh8HkvbwVoDoDKR";
                v.UDictionaryId = AddSys_Dictionary();
                context.Set<Basis_DetectionItme>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DetectionItmeVM));

            Basis_DetectionItmeVM vm = rv.Model as Basis_DetectionItmeVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_DetectionItme();
            v.ID = vm.Entity.ID;
       		
            v.Name = "enXmR";
            v.Code = "dsiKSfkxX7wZYK0Yz";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.UDictionaryId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DetectionItme>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "enXmR");
                Assert.AreEqual(data.Code, "dsiKSfkxX7wZYK0Yz");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_DetectionItme v = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "1JcfuZ58";
                v.Code = "sH7OLh8HkvbwVoDoDKR";
                v.UDictionaryId = AddSys_Dictionary();
                context.Set<Basis_DetectionItme>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DetectionItmeVM));

            Basis_DetectionItmeVM vm = rv.Model as Basis_DetectionItmeVM;
            v = new Basis_DetectionItme();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DetectionItme>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_DetectionItme v = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "1JcfuZ58";
                v.Code = "sH7OLh8HkvbwVoDoDKR";
                v.UDictionaryId = AddSys_Dictionary();
                context.Set<Basis_DetectionItme>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_DetectionItme v1 = new Basis_DetectionItme();
            Basis_DetectionItme v2 = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "1JcfuZ58";
                v1.Code = "sH7OLh8HkvbwVoDoDKR";
                v1.UDictionaryId = AddSys_Dictionary();
                v2.Name = "enXmR";
                v2.Code = "dsiKSfkxX7wZYK0Yz";
                v2.UDictionaryId = v1.UDictionaryId; 
                context.Set<Basis_DetectionItme>().Add(v1);
                context.Set<Basis_DetectionItme>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DetectionItmeBatchVM));

            Basis_DetectionItmeBatchVM vm = rv.Model as Basis_DetectionItmeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_DetectionItme>().Find(v1.ID);
                var data2 = context.Set<Basis_DetectionItme>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_DetectionItme v1 = new Basis_DetectionItme();
            Basis_DetectionItme v2 = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "1JcfuZ58";
                v1.Code = "sH7OLh8HkvbwVoDoDKR";
                v1.UDictionaryId = AddSys_Dictionary();
                v2.Name = "enXmR";
                v2.Code = "dsiKSfkxX7wZYK0Yz";
                v2.UDictionaryId = v1.UDictionaryId; 
                context.Set<Basis_DetectionItme>().Add(v1);
                context.Set<Basis_DetectionItme>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DetectionItmeBatchVM));

            Basis_DetectionItmeBatchVM vm = rv.Model as Basis_DetectionItmeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_DetectionItme>().Find(v1.ID);
                var data2 = context.Set<Basis_DetectionItme>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_DetectionItmeListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "18fj5MbTC7zAx";
                v.Code = "deG";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

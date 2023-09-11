using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_DeviceTypeVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;
using DustWarning.Model.Sys;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_DeviceTypeControllerTest
    {
        private Basis_DeviceTypeController _controller;
        private string _seed;

        public Basis_DeviceTypeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_DeviceTypeController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_DeviceTypeListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceTypeVM));

            Basis_DeviceTypeVM vm = rv.Model as Basis_DeviceTypeVM;
            Basis_DeviceType v = new Basis_DeviceType();
			
            v.Name = "o0Bgjwk5q1HW";
            v.MessageTypeId = AddSys_Dictionary();
            v.AgreementTypeId = AddSys_Dictionary();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DeviceType>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "o0Bgjwk5q1HW");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_DeviceType v = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "o0Bgjwk5q1HW";
                v.MessageTypeId = AddSys_Dictionary();
                v.AgreementTypeId = AddSys_Dictionary();
                context.Set<Basis_DeviceType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceTypeVM));

            Basis_DeviceTypeVM vm = rv.Model as Basis_DeviceTypeVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_DeviceType();
            v.ID = vm.Entity.ID;
       		
            v.Name = "BcFP";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.MessageTypeId", "");
            vm.FC.Add("Entity.AgreementTypeId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DeviceType>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "BcFP");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_DeviceType v = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "o0Bgjwk5q1HW";
                v.MessageTypeId = AddSys_Dictionary();
                v.AgreementTypeId = AddSys_Dictionary();
                context.Set<Basis_DeviceType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceTypeVM));

            Basis_DeviceTypeVM vm = rv.Model as Basis_DeviceTypeVM;
            v = new Basis_DeviceType();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_DeviceType>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_DeviceType v = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "o0Bgjwk5q1HW";
                v.MessageTypeId = AddSys_Dictionary();
                v.AgreementTypeId = AddSys_Dictionary();
                context.Set<Basis_DeviceType>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_DeviceType v1 = new Basis_DeviceType();
            Basis_DeviceType v2 = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "o0Bgjwk5q1HW";
                v1.MessageTypeId = AddSys_Dictionary();
                v1.AgreementTypeId = AddSys_Dictionary();
                v2.Name = "BcFP";
                v2.MessageTypeId = v1.MessageTypeId; 
                v2.AgreementTypeId = v1.AgreementTypeId; 
                context.Set<Basis_DeviceType>().Add(v1);
                context.Set<Basis_DeviceType>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceTypeBatchVM));

            Basis_DeviceTypeBatchVM vm = rv.Model as Basis_DeviceTypeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_DeviceType>().Find(v1.ID);
                var data2 = context.Set<Basis_DeviceType>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_DeviceType v1 = new Basis_DeviceType();
            Basis_DeviceType v2 = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "o0Bgjwk5q1HW";
                v1.MessageTypeId = AddSys_Dictionary();
                v1.AgreementTypeId = AddSys_Dictionary();
                v2.Name = "BcFP";
                v2.MessageTypeId = v1.MessageTypeId; 
                v2.AgreementTypeId = v1.AgreementTypeId; 
                context.Set<Basis_DeviceType>().Add(v1);
                context.Set<Basis_DeviceType>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceTypeBatchVM));

            Basis_DeviceTypeBatchVM vm = rv.Model as Basis_DeviceTypeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_DeviceType>().Find(v1.ID);
                var data2 = context.Set<Basis_DeviceType>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_DeviceTypeListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "IIi1Ugo0ZNdW";
                v.Code = "Q4e9";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

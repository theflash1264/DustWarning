using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_DeviceVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_DeviceControllerTest
    {
        private Basis_DeviceController _controller;
        private string _seed;

        public Basis_DeviceControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_DeviceController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_DeviceListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceVM));

            Basis_DeviceVM vm = rv.Model as Basis_DeviceVM;
            Basis_Device v = new Basis_Device();
			
            v.Name = "FGBhCmJgjTri18vtrY";
            v.Code = "lJ6MVtPBLssTBD6v3";
            v.DTId = AddBasis_DeviceType();
            v.AreaId = AddBasis_Area();
            v.Place = "WtxLS";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Device>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "FGBhCmJgjTri18vtrY");
                Assert.AreEqual(data.Code, "lJ6MVtPBLssTBD6v3");
                Assert.AreEqual(data.Place, "WtxLS");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_Device v = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "FGBhCmJgjTri18vtrY";
                v.Code = "lJ6MVtPBLssTBD6v3";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "WtxLS";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceVM));

            Basis_DeviceVM vm = rv.Model as Basis_DeviceVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_Device();
            v.ID = vm.Entity.ID;
       		
            v.Name = "jSaQLUD1";
            v.Code = "zKiinQbpCxr";
            v.Place = "v";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.DTId", "");
            vm.FC.Add("Entity.AreaId", "");
            vm.FC.Add("Entity.Place", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Device>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "jSaQLUD1");
                Assert.AreEqual(data.Code, "zKiinQbpCxr");
                Assert.AreEqual(data.Place, "v");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_Device v = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "FGBhCmJgjTri18vtrY";
                v.Code = "lJ6MVtPBLssTBD6v3";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "WtxLS";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceVM));

            Basis_DeviceVM vm = rv.Model as Basis_DeviceVM;
            v = new Basis_Device();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Device>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_Device v = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "FGBhCmJgjTri18vtrY";
                v.Code = "lJ6MVtPBLssTBD6v3";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "WtxLS";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_Device v1 = new Basis_Device();
            Basis_Device v2 = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "FGBhCmJgjTri18vtrY";
                v1.Code = "lJ6MVtPBLssTBD6v3";
                v1.DTId = AddBasis_DeviceType();
                v1.AreaId = AddBasis_Area();
                v1.Place = "WtxLS";
                v2.Name = "jSaQLUD1";
                v2.Code = "zKiinQbpCxr";
                v2.DTId = v1.DTId; 
                v2.AreaId = v1.AreaId; 
                v2.Place = "v";
                context.Set<Basis_Device>().Add(v1);
                context.Set<Basis_Device>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceBatchVM));

            Basis_DeviceBatchVM vm = rv.Model as Basis_DeviceBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_Device>().Find(v1.ID);
                var data2 = context.Set<Basis_Device>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_Device v1 = new Basis_Device();
            Basis_Device v2 = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "FGBhCmJgjTri18vtrY";
                v1.Code = "lJ6MVtPBLssTBD6v3";
                v1.DTId = AddBasis_DeviceType();
                v1.AreaId = AddBasis_Area();
                v1.Place = "WtxLS";
                v2.Name = "jSaQLUD1";
                v2.Code = "zKiinQbpCxr";
                v2.DTId = v1.DTId; 
                v2.AreaId = v1.AreaId; 
                v2.Place = "v";
                context.Set<Basis_Device>().Add(v1);
                context.Set<Basis_Device>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_DeviceBatchVM));

            Basis_DeviceBatchVM vm = rv.Model as Basis_DeviceBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_Device>().Find(v1.ID);
                var data2 = context.Set<Basis_Device>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_DeviceListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "K8aQxe0";
                v.Code = "c1Xrq8X8ZiysUuqaHsG";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_DeviceType()
        {
            Basis_DeviceType v = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "KEQS8ctxnD90gjRtZ8j";
                v.MessageTypeId = AddSys_Dictionary();
                v.AgreementTypeId = AddSys_Dictionary();
                context.Set<Basis_DeviceType>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddSys_AreaDictionary()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "2Lvuo8ckDPgv";
                v.AreaCode = "ddWCsSfgTSXF7IAh";
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_Area()
        {
            Basis_Area v = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "xitBHH";
                v.AreaCode = "2D6nK8";
                v.Lng = "FlyN8Ta";
                v.Lat = "DHEVkQZNH8f0xDSxfr";
                v.Remarks = "MA";
                v.AreaId = AddSys_AreaDictionary();
                v.ProvinceId = AddSys_AreaDictionary();
                v.CityId = AddSys_AreaDictionary();
                context.Set<Basis_Area>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

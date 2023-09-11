using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_AreaVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;
using DustWarning.Model.Sys;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_AreaControllerTest
    {
        private Basis_AreaController _controller;
        private string _seed;

        public Basis_AreaControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_AreaController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_AreaListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AreaVM));

            Basis_AreaVM vm = rv.Model as Basis_AreaVM;
            Basis_Area v = new Basis_Area();
			
            v.Name = "evckb";
            v.AreaCode = "bMA2qVYvvpiVICT";
            v.Lng = "wrAWqw5fNCsYSOe";
            v.Lat = "T4X";
            v.Remarks = "a10FPjhX7p6hPHHeNP";
            v.AreaId = AddSys_AreaDictionary();
            v.ProvinceId = AddSys_AreaDictionary();
            v.CityId = AddSys_AreaDictionary();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Area>().Find(v.ID);
				
                Assert.AreEqual(data.Name, "evckb");
                Assert.AreEqual(data.AreaCode, "bMA2qVYvvpiVICT");
                Assert.AreEqual(data.Lng, "wrAWqw5fNCsYSOe");
                Assert.AreEqual(data.Lat, "T4X");
                Assert.AreEqual(data.Remarks, "a10FPjhX7p6hPHHeNP");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_Area v = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "evckb";
                v.AreaCode = "bMA2qVYvvpiVICT";
                v.Lng = "wrAWqw5fNCsYSOe";
                v.Lat = "T4X";
                v.Remarks = "a10FPjhX7p6hPHHeNP";
                v.AreaId = AddSys_AreaDictionary();
                v.ProvinceId = AddSys_AreaDictionary();
                v.CityId = AddSys_AreaDictionary();
                context.Set<Basis_Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AreaVM));

            Basis_AreaVM vm = rv.Model as Basis_AreaVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_Area();
            v.ID = vm.Entity.ID;
       		
            v.Name = "7I1eO7InzKvkZ2yD";
            v.AreaCode = "5XPgt3E";
            v.Lng = "5AvDjEBzP";
            v.Lat = "GaEyoYfE70Ktfiss";
            v.Remarks = "ScGXxrNTTgHWTfUAR3";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.AreaCode", "");
            vm.FC.Add("Entity.Lng", "");
            vm.FC.Add("Entity.Lat", "");
            vm.FC.Add("Entity.Remarks", "");
            vm.FC.Add("Entity.AreaId", "");
            vm.FC.Add("Entity.ProvinceId", "");
            vm.FC.Add("Entity.CityId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Area>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "7I1eO7InzKvkZ2yD");
                Assert.AreEqual(data.AreaCode, "5XPgt3E");
                Assert.AreEqual(data.Lng, "5AvDjEBzP");
                Assert.AreEqual(data.Lat, "GaEyoYfE70Ktfiss");
                Assert.AreEqual(data.Remarks, "ScGXxrNTTgHWTfUAR3");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_Area v = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "evckb";
                v.AreaCode = "bMA2qVYvvpiVICT";
                v.Lng = "wrAWqw5fNCsYSOe";
                v.Lat = "T4X";
                v.Remarks = "a10FPjhX7p6hPHHeNP";
                v.AreaId = AddSys_AreaDictionary();
                v.ProvinceId = AddSys_AreaDictionary();
                v.CityId = AddSys_AreaDictionary();
                context.Set<Basis_Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AreaVM));

            Basis_AreaVM vm = rv.Model as Basis_AreaVM;
            v = new Basis_Area();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_Area>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_Area v = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Name = "evckb";
                v.AreaCode = "bMA2qVYvvpiVICT";
                v.Lng = "wrAWqw5fNCsYSOe";
                v.Lat = "T4X";
                v.Remarks = "a10FPjhX7p6hPHHeNP";
                v.AreaId = AddSys_AreaDictionary();
                v.ProvinceId = AddSys_AreaDictionary();
                v.CityId = AddSys_AreaDictionary();
                context.Set<Basis_Area>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_Area v1 = new Basis_Area();
            Basis_Area v2 = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "evckb";
                v1.AreaCode = "bMA2qVYvvpiVICT";
                v1.Lng = "wrAWqw5fNCsYSOe";
                v1.Lat = "T4X";
                v1.Remarks = "a10FPjhX7p6hPHHeNP";
                v1.AreaId = AddSys_AreaDictionary();
                v1.ProvinceId = AddSys_AreaDictionary();
                v1.CityId = AddSys_AreaDictionary();
                v2.Name = "7I1eO7InzKvkZ2yD";
                v2.AreaCode = "5XPgt3E";
                v2.Lng = "5AvDjEBzP";
                v2.Lat = "GaEyoYfE70Ktfiss";
                v2.Remarks = "ScGXxrNTTgHWTfUAR3";
                v2.AreaId = v1.AreaId; 
                v2.ProvinceId = v1.ProvinceId; 
                v2.CityId = v1.CityId; 
                context.Set<Basis_Area>().Add(v1);
                context.Set<Basis_Area>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AreaBatchVM));

            Basis_AreaBatchVM vm = rv.Model as Basis_AreaBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_Area>().Find(v1.ID);
                var data2 = context.Set<Basis_Area>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_Area v1 = new Basis_Area();
            Basis_Area v2 = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "evckb";
                v1.AreaCode = "bMA2qVYvvpiVICT";
                v1.Lng = "wrAWqw5fNCsYSOe";
                v1.Lat = "T4X";
                v1.Remarks = "a10FPjhX7p6hPHHeNP";
                v1.AreaId = AddSys_AreaDictionary();
                v1.ProvinceId = AddSys_AreaDictionary();
                v1.CityId = AddSys_AreaDictionary();
                v2.Name = "7I1eO7InzKvkZ2yD";
                v2.AreaCode = "5XPgt3E";
                v2.Lng = "5AvDjEBzP";
                v2.Lat = "GaEyoYfE70Ktfiss";
                v2.Remarks = "ScGXxrNTTgHWTfUAR3";
                v2.AreaId = v1.AreaId; 
                v2.ProvinceId = v1.ProvinceId; 
                v2.CityId = v1.CityId; 
                context.Set<Basis_Area>().Add(v1);
                context.Set<Basis_Area>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AreaBatchVM));

            Basis_AreaBatchVM vm = rv.Model as Basis_AreaBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_Area>().Find(v1.ID);
                var data2 = context.Set<Basis_Area>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_AreaListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_AreaDictionary()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "rN";
                v.AreaCode = "gVPANBUAw8F";
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;
using DustWarning.Model.Sys;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_AnalysisAgControllerTest
    {
        private Basis_AnalysisAgController _controller;
        private string _seed;

        public Basis_AnalysisAgControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_AnalysisAgController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_AnalysisAgListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AnalysisAgVM));

            Basis_AnalysisAgVM vm = rv.Model as Basis_AnalysisAgVM;
            Basis_AnalysisAg v = new Basis_AnalysisAg();
			
            v.ADictionaryId = AddSys_Dictionary();
            v.DeviceId = AddBasis_Device();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_AnalysisAg>().Find(v.ID);
				
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_AnalysisAg v = new Basis_AnalysisAg();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ADictionaryId = AddSys_Dictionary();
                v.DeviceId = AddBasis_Device();
                context.Set<Basis_AnalysisAg>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AnalysisAgVM));

            Basis_AnalysisAgVM vm = rv.Model as Basis_AnalysisAgVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_AnalysisAg();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ADictionaryId", "");
            vm.FC.Add("Entity.DeviceId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_AnalysisAg>().Find(v.ID);
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_AnalysisAg v = new Basis_AnalysisAg();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ADictionaryId = AddSys_Dictionary();
                v.DeviceId = AddBasis_Device();
                context.Set<Basis_AnalysisAg>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AnalysisAgVM));

            Basis_AnalysisAgVM vm = rv.Model as Basis_AnalysisAgVM;
            v = new Basis_AnalysisAg();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_AnalysisAg>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_AnalysisAg v = new Basis_AnalysisAg();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ADictionaryId = AddSys_Dictionary();
                v.DeviceId = AddBasis_Device();
                context.Set<Basis_AnalysisAg>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_AnalysisAg v1 = new Basis_AnalysisAg();
            Basis_AnalysisAg v2 = new Basis_AnalysisAg();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ADictionaryId = AddSys_Dictionary();
                v1.DeviceId = AddBasis_Device();
                v2.ADictionaryId = v1.ADictionaryId; 
                v2.DeviceId = v1.DeviceId; 
                context.Set<Basis_AnalysisAg>().Add(v1);
                context.Set<Basis_AnalysisAg>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AnalysisAgBatchVM));

            Basis_AnalysisAgBatchVM vm = rv.Model as Basis_AnalysisAgBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_AnalysisAg>().Find(v1.ID);
                var data2 = context.Set<Basis_AnalysisAg>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_AnalysisAg v1 = new Basis_AnalysisAg();
            Basis_AnalysisAg v2 = new Basis_AnalysisAg();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ADictionaryId = AddSys_Dictionary();
                v1.DeviceId = AddBasis_Device();
                v2.ADictionaryId = v1.ADictionaryId; 
                v2.DeviceId = v1.DeviceId; 
                context.Set<Basis_AnalysisAg>().Add(v1);
                context.Set<Basis_AnalysisAg>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_AnalysisAgBatchVM));

            Basis_AnalysisAgBatchVM vm = rv.Model as Basis_AnalysisAgBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_AnalysisAg>().Find(v1.ID);
                var data2 = context.Set<Basis_AnalysisAg>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_AnalysisAgListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "Wc8DbISrbW9b7yqeICx";
                v.Code = "9pDmb";
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

                v.Name = "cty2";
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

                v.Name = "WO5ESv";
                v.AreaCode = "Y1ohhjEhlkzvorxpaK";
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

                v.Name = "nZFU5oNea2";
                v.AreaCode = "ayN4FtnniGz";
                v.Lng = "vP";
                v.Lat = "JJP";
                v.Remarks = "mP0L7K";
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

        private Guid AddBasis_Device()
        {
            Basis_Device v = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "cqAmZO37aZm842loPW0";
                v.Code = "oPzLhqAGG6gHsuHgGo";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "qE8B36CgkI66SBc";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Helper;
using Newtonsoft.Json;
using yanzhilong.Security;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class JdAutoController : BaseAdminController
    {
        private readonly JdAutoServiceMB _JdAutoMb;
        private readonly JdAutoPropertyValueServiceMB _JdAutoPropertyValueMB;


        public JdAutoController(JdAutoServiceMB jdAutoMB, JdAutoPropertyValueServiceMB _jdAutoPropertyValueMB)
        {
            _JdAutoMb = jdAutoMB;
            _JdAutoPropertyValueMB = _jdAutoPropertyValueMB;
        }

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AccessDeniedView();

            return View();
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var entrys = _JdAutoMb.GetEntrys(null);
            IEnumerable<JdAutoModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        public ActionResult Copy(string Id)
        {
            JdAuto ja = _JdAutoMb.GetEntry(new JdAuto { Id = Id });
            ja.Id = Guid.NewGuid().ToString();
            List<JdAutoPropertyValue> jpvs = _JdAutoPropertyValueMB.GetEntrys(new JdAutoPropertyValue { JdAutoId = Id }).ToList<JdAutoPropertyValue>();
            foreach(JdAutoPropertyValue jpv in jpvs)
            {
                jpv.Id = Guid.NewGuid().ToString();
                jpv.JdAutoId = ja.Id;
            }
            _JdAutoMb.AddEntry(ja);
            _JdAutoPropertyValueMB.AddEntrys(jpvs);
            return View("Index");
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdAuto> entrys = models.Select(e => e.ToEntity());
                _JdAutoMb.UpdateEntrys(entrys.ToList <JdAuto> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (JdAutoModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<JdAuto> entrys = models.Select(e => e.ToEntity());
                _JdAutoMb.AddEntrys(entrys.ToList<JdAuto>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdAuto> entrys = models.Select(e => e.ToEntity());
                foreach (JdAuto ja in entrys)
                {
                    List<JdAutoPropertyValue> jpvs = _JdAutoPropertyValueMB.GetEntrys(new JdAutoPropertyValue { JdAutoId = ja.Id }).ToList();
                    _JdAutoPropertyValueMB.DeleteEntrys(jpvs);
                    _JdAutoMb.DeleteEntry(ja);
                }
            }
            return Json(models);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer.Contracts;
using TestModel.Common;

namespace TestModel.BusinessLayer.Implementation
{
    [Export(typeof(IGoodProductBusinessLayer))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetGoodProductBusinessLayer : IGoodProductBusinessLayer
    {
        public string GetAllProduct()
        {
            var uss = MefContainer.GetImplementationObject<IUserManagementBusinessLayer>();

            throw new NotImplementedException();
        }

        public string GetAwesomeProduct()
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using OopFactory.X12.Parsing;
using OopFactory.X12.Parsing.Model;

namespace OopFactory.X12.Tests.Unit.Parsing.Claims.ProfessionalClaims
{
    [TestClass]
    public class ProfessionalClaimParsingTester
    {
        private Stream GetEdi(string filename)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream("OopFactory.X12.Tests.Unit.Parsing.Claims.ProfessionalClaims." + filename);
        }

        [TestMethod]
        public void ParseSample1ToXml()
        {
            X12Parser parser = new X12Parser();
            Interchange interchange = parser.Parse(GetEdi("Sample1_5010.txt"));
            string xml = interchange.Serialize();
            Trace.Write(xml);
        }

        [TestMethod]
        public void ParseSample1AndUnparse()
        {
            X12Parser parser = new X12Parser();
            Interchange interchange = parser.Parse(GetEdi("Sample1_5010.txt"));
            string x12 = interchange.SerializeToX12(true);
            Trace.Write(x12);
        }
    }
}
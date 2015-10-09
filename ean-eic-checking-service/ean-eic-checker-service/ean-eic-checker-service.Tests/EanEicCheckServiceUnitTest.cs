﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ean_eic_checker_service.Models;
using ean_eic_checker_service.Services;

namespace ean_eic_checker_service.Tests {
    //TODO: test more valid EAN/EIC codes

    [TestClass]
    public class EanEicCheckServiceUnitTest
    {
        private EanEicCheckService _service;
        private readonly EanEicCode _validEan = new EanEicCode("859182400123456789");
        private readonly EanEicCode _nonDigitEan = new EanEicCode("859x82D00&*(4567▼˘");
        private readonly EanEicCode _invalidSumcheckEan = new EanEicCode("859182400123456784");
        private readonly EanEicCode _tooLongEan = new EanEicCode("859182400123456789654465");
        private readonly EanEicCode _tooShortEan = new EanEicCode("859182400129");


        private readonly EanEicCode _validEic = new EanEicCode("27ZG600Z0424987D");
        private readonly EanEicCode _invalidSumcheckEic = new EanEicCode("27ZG600Z0424987Q");
        private readonly EanEicCode _invalidCharacterEic = new EanEicCode("27ZG6^%$÷˘2▼987D");
        private readonly EanEicCode _tooLongEic = new EanEicCode("27ZG600Z0424987ASDF234D");
        private readonly EanEicCode _tooShortEic = new EanEicCode("27ZG600Z4287D");

        private readonly EanEicCode _invalidPrefix = new EanEicCode("X9ZG600Z0424987D");


        [TestInitialize]
        public void SetUp()
        {
            _service = new EanEicCheckService();
        }

        [TestMethod]
        public void TestValidEan()
        {
            CheckResult res = _service.CheckCode(_validEan);
            Assert.AreEqual(CheckResultCode.EanOk, res.ResultCode);
        }

        [TestMethod]
        public void TestValidEic() {
            CheckResult res = _service.CheckCode(_validEic);
            Assert.AreEqual(CheckResultCode.EicOk, res.ResultCode);
        }

        [TestMethod]
        public void TestInvalidPrefix() {
            //TODO: validate, that EIC really needs to start with the 27 (in docs example there was EIC starting with '11')
            CheckResult res = _service.CheckCode(_invalidPrefix);
            Assert.AreEqual(CheckResultCode.CodePrefixInvalid, res.ResultCode);
        }

        [TestMethod]
        public void TestTooLongEanLength() {
            CheckResult res = _service.CheckCode(_tooLongEan);
            Assert.AreEqual(CheckResultCode.EanInvalidLength, res.ResultCode);
        }

        [TestMethod]
        public void TestTooShortEanLength() {
            CheckResult res = _service.CheckCode(_tooShortEan);
            Assert.AreEqual(CheckResultCode.EanInvalidLength, res.ResultCode);
        }

        [TestMethod]
        public void TestTooLongEicLength() {
            CheckResult res = _service.CheckCode(_tooLongEic);
            Assert.AreEqual(CheckResultCode.EicInvalidLength, res.ResultCode);
        }

        [TestMethod]
        public void TestTooShortEicLength() {
            CheckResult res = _service.CheckCode(_tooShortEic);
            Assert.AreEqual(CheckResultCode.EicInvalidLength, res.ResultCode);
        }

        [TestMethod]
        public void TestEmptyCode() {
            CheckResult res = _service.CheckCode(new EanEicCode(""));
            Assert.AreEqual(CheckResultCode.NoCodeSupplied, res.ResultCode);
        }

        [TestMethod]
        public void TestNullCode() {
            CheckResult res = _service.CheckCode(new EanEicCode(null));
            Assert.AreEqual(CheckResultCode.NoCodeSupplied, res.ResultCode);
        }

        [TestMethod]
        public void TestNonDigitCharacterEan() {
            CheckResult res = _service.CheckCode(_nonDigitEan);
            Assert.AreEqual(CheckResultCode.EanInvalidCharacter, res.ResultCode);
        }

        [TestMethod]
        public void TestInvalidCharacterEic() {
            CheckResult res = _service.CheckCode(_invalidCharacterEic);
            Assert.AreEqual(CheckResultCode.EicInvalidCharacter, res.ResultCode);
        }

        [TestMethod]
        public void TestInvalidSumcheckEan() {
            CheckResult res = _service.CheckCode(_invalidSumcheckEan);
            Assert.AreEqual(CheckResultCode.EanInvalidCheckCharacter, res.ResultCode);
        }
    
        [TestMethod]
        public void TestInvalidSumcheckEic() {
            CheckResult res = _service.CheckCode(_invalidSumcheckEic);
            Assert.AreEqual(CheckResultCode.EicInvalidCheckCharacter, res.ResultCode);
        }
    }
}
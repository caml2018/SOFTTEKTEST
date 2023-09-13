using Microsoft.AspNetCore.Http;
using Moq;
using Org.BouncyCastle.Crypto.Tls;
using softtek.api.Controllers;
using softtek.domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.Json;
using Xunit;

namespace softtek.api.test
{
    public class ApiTest:TestBuilder
    {
        
        [Fact]
        public async void ServicioDescargaInformeRegistrosNoCargados()
        {
            var carga = this.TestClient.GetAsync("/api/InformeResultado").Result;
            var value=carga.StatusCode;
            Assert.Equal(HttpStatusCode.NotFound, value);
        }

        [Fact]
        public async void readFileOk()
        {
            MayoryBalance mayoryBalance = new MayoryBalance();
            FileUploadModel fileUploadModel= new FileUploadModel();

            string path = @"C:\tmp";
            var filePath = Path.Combine(path, "INICIAL RV.xls");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            IFormFile formFile = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, null, Path.GetFileName(filePath))
            {
                Headers= new HeaderDictionary(),
                ContentType="application/json",
            };

            fileUploadModel.FileDetails= formFile;

            var result = mayoryBalance.readXmlDocument(fileUploadModel);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void readFileError()
        {
            MayoryBalance mayoryBalance = new MayoryBalance();
            FileUploadModel fileUploadModel = new FileUploadModel();

            string path = @"C:\tmp";
            var filePath = Path.Combine(path, "AUX MES.xls");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            IFormFile formFile = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, null, Path.GetFileName(filePath))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };

            fileUploadModel.FileDetails = formFile;
            //Act
            var respones =Assert.Throws<Exception>(() => mayoryBalance.readXmlDocument(fileUploadModel));

            //Assert
            Assert.Equal("Object cannot be cast from DBNull to other types.", respones.Message);
        }

        [Fact]
        public async void readFileNotLoaded()
        {
            MayoryBalance mayoryBalance = new MayoryBalance();
            FileUploadModel fileUploadModel = new FileUploadModel();

            //Act
            var respones=Assert.Throws<Exception>(() => mayoryBalance.readXmlDocument(fileUploadModel));

            //Assert
            Assert.Equal("Object reference not set to an instance of an object.", respones.Message);

        }

        [Fact]
        public async void getPdfOk()
        {
            //Arrange
            MayoryBalance mayoryBalance = new MayoryBalance();

            var lstMayoryBalance = new List<MayoryBalance> { 
                new MayoryBalance {Id=40, Cuenta="41459501",NombreCuenta="Null", Tercero= "1085266000", SaldoFinal= (decimal)-1800.00, mensaje_naturaleza="",mensaje_ajusteaceros="Ajuste al peso"},
                new MayoryBalance {Id=108, Cuenta="28050501A",NombreCuenta="Null", Tercero= "830109723", SaldoFinal= (decimal)-1919.66, mensaje_naturaleza="",mensaje_ajusteaceros="Ajuste al peso"},
                new MayoryBalance {Id=115, Cuenta="25200501",NombreCuenta="Null", Tercero= "9868127", SaldoFinal= (decimal)0.04, mensaje_naturaleza="Cuenta Volteada",mensaje_ajusteaceros="Ajuste al peso"}
            };

            //Act
            var respuesta = mayoryBalance.getReport(lstMayoryBalance);

            //Assert
            Assert.True(!string.IsNullOrEmpty(respuesta));

        }
        [Fact]
        public async void getPdfError()
        {
            //Arrange
            MayoryBalance mayoryBalance = new MayoryBalance();

            var lstMayoryBalance = new List<MayoryBalance>(); 

            //Assert
            Assert.Throws<Exception>(() => mayoryBalance.getReport(lstMayoryBalance));

        }

        
    }
}

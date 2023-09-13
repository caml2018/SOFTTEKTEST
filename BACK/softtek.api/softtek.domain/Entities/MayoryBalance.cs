using ExcelDataReader;
using softtek.domain.Bussines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;

namespace softtek.domain.Entities
{
    public class MayoryBalance
    {
        [Key]
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string NombreCuenta { get; set; }
        public string Tercero { get; set; }
        public Decimal SaldoInicial { get; set; }
        public Decimal SaldoFinal { get; set; }
        public Decimal Debito { get; set; }
        public Decimal Credito { get; set; }
        public string? mensaje_naturaleza { get; set; }
        public string? mensaje_ajusteaceros { get; set; }

        public List<MayoryBalance> readXmlDocument(FileUploadModel fileDetails)
        {
            try
            {
                if (fileDetails.FileDetails == null)
                    throw new NullReferenceException();
                List<MayoryBalance> lstMayoryBalance = new List<MayoryBalance>();
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    fileDetails.FileDetails.CopyTo(stream);
                    stream.Position = 0;
                    using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = excelReader.AsDataSet();
                        for (int j = 1; j < result.Tables[0].Rows.Count; j++)
                        {
                            var x = result.Tables[0].Rows[j];
                            MayoryBalance mayoryBalance = new MayoryBalance();
                            mayoryBalance.Cuenta = x.ItemArray[0].ToString();
                            mayoryBalance.NombreCuenta = x.ItemArray[1] != null ? x.ItemArray[1].ToString() : "";
                            mayoryBalance.Tercero = x.ItemArray[2] != null ? x.ItemArray[2].ToString() : "";
                            mayoryBalance.SaldoInicial = Math.Truncate(Convert.ToDecimal(x.ItemArray[3]) * 100) / 100;
                            mayoryBalance.SaldoFinal = Math.Truncate(Convert.ToDecimal(x.ItemArray[6])) / 100;
                            mayoryBalance.Debito = Math.Truncate(Convert.ToDecimal(x.ItemArray[4]) * 100) / 100;
                            mayoryBalance.Credito = Math.Truncate(Convert.ToDecimal(x.ItemArray[5]) * 100) / 100;
                            lstMayoryBalance.Add(mayoryBalance);
                        }
                    }
                }
                return lstMayoryBalance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string getReport(List<MayoryBalance> lstMayoryBalance)
        {
            return GetPdfReport.generate(lstMayoryBalance);
        }
    }
}

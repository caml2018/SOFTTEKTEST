using iTextSharp.text;
using iTextSharp.text.pdf;
using softtek.domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace softtek.domain.Bussines
{
    public static class GetPdfReport
    {
        public static string generate(List<MayoryBalance> entity)
        {
            if (entity.Count <= 0)
                throw new Exception("Registros No encontrados");
            string rutaFormato = "C:\\OIKOSOFT\\FORMATOS\\Formato Informe softtek.pdf";
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfReader pdfReader = new PdfReader(rutaFormato))
                {
                    Document document = new Document(pdfReader.GetPageSize(1));
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, ms);
                    try
                    {
                        var pageSize = pdfReader.GetPageSize(1);
                        pdfStamper.FormFlattening = true;
                        AcroFields pdfFormFields = pdfStamper.AcroFields;
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        BaseFont bf3 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA, 5.5f, Font.BOLD);

                        Font tmpfont = new Font(bf, 8f);
                        Font tmpfont2 = new Font(bf2, 8f);
                        Font tmpfont3 = new Font(bf2, 7f);
                        Font tmpfont4 = new Font(bf2, 9f);
                        Font tmpfont5 = new Font(bf3, 8f);
                        Font tmpfont6 = new Font(bf2, 6.5f);
                        Font tmpfont7 = new Font(bf2, 5.5f);

                        PdfContentByte canvas = pdfStamper.GetOverContent(1);

                        float lineainicioInforme = 90;
                        float lineasiguiente = 0;
                        int numeroInicialDeLineas = 0;
                        int numeroMaximoDeLineas = 60;
                        int numeroDePagina = 1;

                        string tituloDelInforme = "INFORME: VALIDACIÓN MOVIMIENTO CONTABLAE";
                        string fechaDelInforme = $"FECHA:{DateTime.Now.ToString("dd-MM-yyyy")}";
                        string clienteOiko = "CLIENTE: GENERAL";
                        string headerTablaCuenta = "CUENTA";
                        string headerTablaNombreCuenta = "NOMBRE CUENTA";
                        string headerTablaTercero = "TERCERO";
                        string headerTablaValor = "VALOR";
                        string headerTablaObservacion = "OBSERVACION";

                        Phrase phTituloDelInforme = new Phrase(tituloDelInforme, tmpfont);
                        Phrase phFechaDelInforme = new Phrase(fechaDelInforme, tmpfont);
                        Phrase phClienteOiko = new Phrase(clienteOiko, tmpfont);
                        Phrase phHeaderTablaCuenta = new Phrase(headerTablaCuenta, tmpfont);
                        Phrase phHeaderTablaNombreCuenta = new Phrase(headerTablaNombreCuenta, tmpfont);
                        Phrase phHeaderTablaTercero = new Phrase(headerTablaTercero, tmpfont);
                        Phrase phHeaderTablaValor = new Phrase(headerTablaValor, tmpfont);
                        Phrase phHeaderTablaObservacion = new Phrase(headerTablaObservacion, tmpfont);

                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phTituloDelInforme, Utilities.MillimetersToPoints(50), pageSize.GetTop(Utilities.MillimetersToPoints(20)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phFechaDelInforme, Utilities.MillimetersToPoints(50), pageSize.GetTop(Utilities.MillimetersToPoints(30)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phClienteOiko, Utilities.MillimetersToPoints(50), pageSize.GetTop(Utilities.MillimetersToPoints(40)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phHeaderTablaCuenta, Utilities.MillimetersToPoints(10), pageSize.GetTop(Utilities.MillimetersToPoints(80)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phHeaderTablaNombreCuenta, Utilities.MillimetersToPoints(30), pageSize.GetTop(Utilities.MillimetersToPoints(80)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phHeaderTablaTercero, Utilities.MillimetersToPoints(120), pageSize.GetTop(Utilities.MillimetersToPoints(80)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phHeaderTablaValor, Utilities.MillimetersToPoints(140), pageSize.GetTop(Utilities.MillimetersToPoints(80)), 0);
                        ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phHeaderTablaObservacion, Utilities.MillimetersToPoints(160), pageSize.GetTop(Utilities.MillimetersToPoints(80)), 0);

                        lineasiguiente = lineainicioInforme;
                        foreach (MayoryBalance informe in entity)
                        {
                            if (numeroInicialDeLineas == numeroMaximoDeLineas || numeroInicialDeLineas == entity.Count())
                            {
                                numeroInicialDeLineas = 0;
                                numeroDePagina += 1;
                                numeroMaximoDeLineas = 90;
                                lineainicioInforme = 10;
                                lineasiguiente = lineainicioInforme;
                                pdfStamper.InsertPage(numeroDePagina, pdfReader.GetPageSize(1));
                                canvas = pdfStamper.GetOverContent(numeroDePagina);
                            }
                            Phrase phCuenta = new Phrase(informe.Cuenta.ToString(), tmpfont7);
                            Phrase phNombreCuenta = new Phrase(informe.NombreCuenta, tmpfont7);
                            Phrase phTercero = new Phrase(informe.Tercero, tmpfont7);
                            Phrase phValor = new Phrase(informe.SaldoFinal.ToString(), tmpfont7);
                            Phrase phObservaciones = new Phrase(informe.mensaje_naturaleza +" "+informe.mensaje_ajusteaceros, tmpfont7);
                            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phCuenta, Utilities.MillimetersToPoints(10), pageSize.GetTop(Utilities.MillimetersToPoints(lineasiguiente)), 0);
                            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phNombreCuenta, Utilities.MillimetersToPoints(20), pageSize.GetTop(Utilities.MillimetersToPoints(lineasiguiente)), 0);
                            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phTercero, Utilities.MillimetersToPoints(120), pageSize.GetTop(Utilities.MillimetersToPoints(lineasiguiente)), 0);
                            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phValor, Utilities.MillimetersToPoints(140), pageSize.GetTop(Utilities.MillimetersToPoints(lineasiguiente)), 0);
                            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, phObservaciones, Utilities.MillimetersToPoints(160), pageSize.GetTop(Utilities.MillimetersToPoints(lineasiguiente)), 0);
                            lineasiguiente += 3;
                            numeroInicialDeLineas++;
                        }

                        pdfStamper.GetUnderContent(1).SetLiteral("un literarl");
                        pdfStamper.FreeTextFlattening = true;
                        pdfStamper.Writer.CloseStream = true;
                        pdfStamper.Close();
                    }
                    catch
                    {

                    }
                }
                string base64String = Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);// ms.ToArray();
                return base64String;
            }
        }
    }
}

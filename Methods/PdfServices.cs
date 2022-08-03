using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace DrawingPdf.Methods
{
    public class PdfServices
    {

        public void CreatePdf()
        {
            //Creamos el documento con el tamano  de pagina tradicional
            Document doc = new Document( PageSize.A4);
            //Indicamos donde vamos a guardar el documento 
            PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream("wwwroot/file/prueba.pdf", FileMode.Create));


            //Creamos la imagen y le ajustamo el tamano 

            Image image = Image.GetInstance("wwwroot/images/sigerdLogo.jpg"); 
            image.BorderWidth = 0;
            image.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / image.Width;
            image.ScalePercent(percentage * 80);

            //Le colocamos el titulo y el autor 
            //doc.AddTitle("Mi primer pdf");
            //doc.AddCreator("Miguel Angel");

            //Abrimos el archivo 
            doc.Open();


            //Creamo el tipo de font que vamos a utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //doc.Add(image);

            // Escribimos el encabezamiento en el documento
            Paragraph p = new Paragraph();
            p.Add(new Chunk(image,0,-50));
           
            doc.Add(Chunk.NEWLINE);
            doc.Add(p);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
        }

        public byte[] GenerarPdfMemoryStream()
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4);
                doc.SetMargins(40f, 40f, 40f, 40f);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.NORMAL, new BaseColor(87,89,87));


                //Creamos la imagen y le ajustamo el tamano 

                Image image = Image.GetInstance("wwwroot/images/sigerdLogo.jpg");
                image.BorderWidth = 0;
                image.Alignment = Element.ALIGN_LEFT;
                float percentage = 0.0f;
                percentage = 150 / image.Width;
                image.ScalePercent(percentage * 80);
                Paragraph p = new Paragraph();
                p.Add(new Chunk(image, 0, -80));




                doc.AddAuthor("Miguel");
                doc.AddTitle("Hola");
                doc.Open();
                doc.Add(p);
                doc.Add(new Paragraph("Reporte de Estudiantes con tres o mas \n ausencias consecutivas", _standardFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Chunk(Chunk.NEWLINE));
                doc.Add(new Paragraph($"Fecha / Hora: {DateTime.UtcNow.AddHours(-4)}", _standardFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Chunk(Chunk.NEWLINE));


                var tbl = new PdfPTable(new float[] { 25f, 50f, 20f, 20f, 20f, 25f }) { WidthPercentage = 100f};

                tbl.AddCell(new Phrase("Id Estudiante"));
                tbl.AddCell(new Phrase("Nombre Completo"));
                tbl.AddCell(new Phrase("Nivel"));
                tbl.AddCell(new Phrase("Grado"));
                tbl.AddCell(new Phrase("Seccion"));
                tbl.AddCell(new Phrase("Ausencia Consecutivas"));
                doc.Add(tbl);

                
                doc.Close();
                writer.Close();
                data = ms.ToArray();
            }
           
            return data;
        }

        public byte[] GenerarPdfMemoryStreamToTabla()
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {

                //Creamos el documento
                Document doc = new Document(PageSize.A4);
                //Configuramos el margen del documentos
                doc.SetMargins(40f, 40f, 40f, 40f);
                //Creamos el pdf en la memoria
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                //Configuracion de fonts
                Font titulo = new Font(Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD, new BaseColor(20, 150, 246));
                Font subtitulo = new Font(Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, new BaseColor(20, 150, 246));
                Font parrafo = new Font(Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));

                doc.Open();
                //Agregamos la imagen
                Image image = Image.GetInstance("wwwroot/images/sigerdLogo.jpg");
                image.BorderWidth = 0;
                image.Alignment = Element.ALIGN_LEFT;
                float percentage = 0.0f;
                percentage = 150 / image.Width;
                image.ScalePercent(percentage * 80);
                //Creamos la tabla de la cabecera 
                var tb = new PdfPTable(new float[] { 30f, 70f }) { WidthPercentage = 100};
                tb.AddCell(new PdfPCell(new Paragraph(new Chunk(image, 0, -60))) { Border = 0, Rowspan = 3});
                tb.AddCell(new PdfPCell(new Paragraph("Reporte de Estudiantes con tres o mas \n ausencias consecutivas", titulo) { Alignment = Element.ALIGN_CENTER }) { Border = 0,HorizontalAlignment = Element.ALIGN_CENTER });
                tb.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });
                tb.AddCell(new PdfPCell(new Paragraph($"Fecha / Hora: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}", subtitulo) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(tb);
                //Espacio en blanco para separar el en cabezado
                doc.Add(new Phrase(" \n "));
                doc.Add(new Phrase(" \n "));            
                //Creamos la tabla de Informacion
                tb = new PdfPTable(new float[] { 25f, 25f, 25f, 25f }) { WidthPercentage = 100 };
                var col1 = new PdfPCell(new Phrase("Dirección Regional", parrafo)) { HorizontalAlignment = Element.ALIGN_BASELINE};
                var col2 = new PdfPCell(new Phrase("name", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_BASELINE };
                var col3 = new PdfPCell(new Phrase("Distrito Educativo", parrafo)) { HorizontalAlignment = Element.ALIGN_BASELINE };
                var col4 = new PdfPCell(new Phrase("name", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_BASELINE };
                
                tb.AddCell(col1);
                tb.AddCell(col2);
                tb.AddCell(col3);
                tb.AddCell(col4);
                //Agregamos la tabla de los campos direccion regional y distrito educativo 
                doc.Add(tb);
                //Salto de linea
                doc.Add(new Phrase(" "));
                //Tabla del campo centro educativo
                tb = new PdfPTable(new float[] { 25f, 75f }) { WidthPercentage = 100 };
                var colCentroEducativoLabel = new PdfPCell(new Phrase("Centro Educativo", parrafo)) { HorizontalAlignment = Element.ALIGN_BASELINE };
                var colCentroEducativoName = new PdfPCell(new Phrase("name", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_BASELINE };
                tb.AddCell(colCentroEducativoLabel);
                tb.AddCell(colCentroEducativoName);
                doc.Add(tb);


                doc.Close();
                writer.Close();
                data = ms.ToArray();
            }

            return data;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.com.channeladvisor.api;
using WindowsFormsApplication1.CurrencyConversionWS;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void retrieve_btn_Click(object sender, EventArgs e)
        {
            // Create your credentials


            

            APICredentials cred = new APICredentials();
            cred.DeveloperKey = "2476c33f-a06b-41f7-8af3-3f337bbfdca6";
            cred.Password = "kennyb15";

            // Create the Web Service and attach the credentials
            InventoryService svc = new InventoryService();
            svc.APICredentialsValue = cred;


            string[] skuList = new string[1];
            skuList[0] = sku.Text;

            APIResultOfBoolean result0 = svc.DoesSkuExist("afe6a7ba-dd0c-4292-827d-4385fba66ae2", skuList[0]);
            if (result0.ResultData == false)
            {

                MessageBox.Show("Sku Does Not Exist");

            }

            APIResultOfArrayOfImageInfoResponse result9 = svc.GetInventoryItemImageList("afe6a7ba-dd0c-4292-827d-4385fba66ae2", skuList[0]);
            APIResultOfArrayOfInventoryItemResponse result1 = svc.GetInventoryItemList("afe6a7ba-dd0c-4292-827d-4385fba66ae2", skuList);
            APIResultOfArrayOfAttributeInfo result2 = svc.GetInventoryItemAttributeList("afe6a7ba-dd0c-4292-827d-4385fba66ae2", skuList[0]);


            title.Text = result1.ResultData[0].Title;
            asin.Text = result1.ResultData[0].ASIN;
            upc.Text = result1.ResultData[0].UPC;
            shortdesc.Text = result1.ResultData[0].ShortDescription;
            longdesc.Text = result1.ResultData[0].Description;
            location.Text = result1.ResultData[0].WarehouseLocation;
            startingprice.Text = result1.ResultData[0].PriceInfo.StartingPrice.Value.ToString();
            quantity.Text = result1.ResultData[0].QuantityInfo.Total.ToString();
            amazontitle.Text = result2.ResultData[12].Value;
            amazonshippingoverride.Text = result2.ResultData[59].Value;
            automaticmodepriceoutput.Text = result2.ResultData[57].Value;
            buyprice.Text = Text = result2.ResultData[13].Value;
            buytitle.Text = result2.ResultData[18].Value;
            ceiling.Text = result2.ResultData[68].Value;

            try
            {
                imageurl.Text = result9.ResultData[0].Url;
            }


            catch
            {

            }

        }


        public void Form1_Load(object sender, EventArgs e)
        {

            CurrencyConversionWS.CurrencyConvertor objWS = new CurrencyConversionWS.CurrencyConvertor();
            double usdToinr = objWS.ConversionRate(CurrencyConversionWS.Currency.USD, CurrencyConversionWS.Currency.GBP);
            double totalAmount = usdToinr * 1;
            uk.Text = totalAmount.ToString();
            
            CurrencyConversionWS.CurrencyConvertor objWS2 = new CurrencyConversionWS.CurrencyConvertor();
            double usdToinr2 = objWS2.ConversionRate(CurrencyConversionWS.Currency.USD, CurrencyConversionWS.Currency.AUD);
            double totalAmount2 = usdToinr2 * 1;
            au.Text = totalAmount2.ToString();

            CurrencyConversionWS.CurrencyConvertor objWS3 = new CurrencyConversionWS.CurrencyConvertor();
            double usdToinr3 = objWS3.ConversionRate(CurrencyConversionWS.Currency.USD, CurrencyConversionWS.Currency.JPY);
            double totalAmount3 = usdToinr3 * 1;
            jp.Text = totalAmount3.ToString();

           
        }

        private void update_btn_Click(object sender, EventArgs e)
        {


            
            
            CurrencyConversionWS.CurrencyConvertor objWS2 = new CurrencyConversionWS.CurrencyConvertor();
            double usdToinr2 = objWS2.ConversionRate(CurrencyConversionWS.Currency.AUD, CurrencyConversionWS.Currency.USD);
            double totalAmount2 = usdToinr2 * 1;
            

            CurrencyConversionWS.CurrencyConvertor objWS3 = new CurrencyConversionWS.CurrencyConvertor();
            double usdToinr3 = objWS3.ConversionRate(CurrencyConversionWS.Currency.USD, CurrencyConversionWS.Currency.JPY);
            double totalAmount3 = usdToinr3 * 1;
            

            APICredentials cred = new APICredentials();
            cred.DeveloperKey = "2476c33f-a06b-41f7-8af3-3f337bbfdca6";
            cred.Password = "kennyb15";

            // Create the Web Service and attach the credentials
            InventoryService svc = new InventoryService();
            svc.APICredentialsValue = cred;


            List<ImageInfoSubmit> imgs = new List<ImageInfoSubmit>();
            ImageInfoSubmit img1 = new ImageInfoSubmit();
            img1.PlacementName = "ITEMIMAGEURL1";
            img1.FolderName = null;
            img1.FilenameOrUrl = imageurl.Text;
            imgs.Add(img1);

            
            List<AttributeInfo> attrs = new List<AttributeInfo>();
            
            AttributeInfo attr1 = new AttributeInfo();
            attr1.Name = "Amazon Title";
            attr1.Value = amazontitle.Text;
            attrs.Add(attr1);
            
            AttributeInfo attr2 = new AttributeInfo();
            attr2.Name = "Amazon Shipping Override";
            attr2.Value = amazonshippingoverride.Text;
            attrs.Add(attr2);
            
            AttributeInfo attr3 = new AttributeInfo();
            attr3.Name = "Automatic Mode Price Output";
            attr3.Value = automaticmodepriceoutput.Text;
            attrs.Add(attr3);
            
            AttributeInfo attr4 = new AttributeInfo();
            attr4.Name = "Buy Price";
            attr4.Value = buyprice.Text;
            attrs.Add(attr4);
            
            AttributeInfo attr5 = new AttributeInfo();
            attr5.Name = "Buy Title";
            attr5.Value = buytitle.Text;
            attrs.Add(attr5);
            
            AttributeInfo attr6 = new AttributeInfo();
            attr6.Name = "ceiling";
            attr6.Value = ceiling.Text;
            attrs.Add(attr6);
            
            InventoryItemSubmit douche = new InventoryItemSubmit();
            InventoryItemSubmit douche2 = new InventoryItemSubmit();
            InventoryItemSubmit douche3 = new InventoryItemSubmit();
            
            douche.Sku = sku.Text;
            douche.Title = title.Text;
            douche.ASIN = asin.Text;
            douche.UPC = upc.Text;
            douche.ShortDescription = shortdesc.Text;
            douche.Description = longdesc.Text;
            douche.WarehouseLocation = location.Text;
            

            douche.QuantityInfo = new QuantityInfoSubmit();
            douche.QuantityInfo.UpdateType = "UnShipped";
            douche.QuantityInfo.Total = Convert.ToInt32(quantity.Text);


            
            string fart = startingprice.Text;
            decimal shit = Convert.ToDecimal(fart);

            douche.PriceInfo = new PriceInfo();
            douche.PriceInfo.StartingPrice = shit;
            douche.ImageList = imgs.ToArray();
            douche.AttributeList = attrs.ToArray();

            douche2.Sku = sku.Text;
            douche2.Title = title.Text;
            douche2.ASIN = asin.Text;
            douche2.UPC = upc.Text;
            douche2.ShortDescription = shortdesc.Text;
            douche2.Description = longdesc.Text;
            douche2.WarehouseLocation = location.Text;


            

            

            string fart2 = startingprice.Text;
            double shitter = Convert.ToDouble(fart2);
            double fuckz = shitter / totalAmount2;

            decimal shit2 = Convert.ToDecimal(fuckz);

           


            List<AttributeInfo> attrsa = new List<AttributeInfo>();

            AttributeInfo attra1 = new AttributeInfo();
            attra1.Name = "Amazon Title";
            attra1.Value = amazontitle.Text;
            attrsa.Add(attra1);

            AttributeInfo attra2 = new AttributeInfo();
            attra2.Name = "Amazon Shipping Override";
            double clark = Convert.ToDouble(amazonshippingoverride.Text);
            double clark2 = clark / totalAmount2;
            if (clark2 < 4.50)
            {
                clark2 = 4.50;
            }
            attra2.Value = clark2.ToString();
            attrsa.Add(attra2);

            AttributeInfo attra3 = new AttributeInfo();
            attra3.Name = "Automatic Mode Price Output";
            double mark = Convert.ToDouble(automaticmodepriceoutput.Text);
            double mark2 = mark / totalAmount2;
            attra3.Value = mark2.ToString();
            attrsa.Add(attra3);

            AttributeInfo attra4 = new AttributeInfo();
            attra4.Name = "Buy Price";
            double penny = Convert.ToDouble(buyprice.Text);
            double penny2 = penny / totalAmount2;
            attra4.Value = penny2.ToString();
            attrsa.Add(attra4);

            AttributeInfo attra5 = new AttributeInfo();
            attra5.Name = "Buy Title";
            attra5.Value = buytitle.Text;
            attrsa.Add(attra5);

            AttributeInfo attra6 = new AttributeInfo();
            attra6.Name = "ceiling";
            double dave = Convert.ToDouble(ceiling.Text);
            double dave2 = dave / totalAmount2;
            attra6.Value = dave2.ToString();
            attrsa.Add(attra6);
            

            douche2.PriceInfo = new PriceInfo();
            douche2.PriceInfo.StartingPrice = shit2;
            douche2.ImageList = imgs.ToArray();
            douche2.AttributeList = attrsa.ToArray();

            

            douche3.Sku = sku.Text;
            douche3.Title = title.Text;
            douche3.ASIN = asin.Text;
            douche3.UPC = upc.Text;
            douche3.ShortDescription = shortdesc.Text;
            douche3.Description = longdesc.Text;
            douche3.WarehouseLocation = location.Text;






            string fart3 = startingprice.Text;
            double shitter3 = Convert.ToDouble(fart3);
            double fuckz3 = shitter3 * totalAmount3;

            decimal shit3 = Convert.ToDecimal(fuckz3);




            List<AttributeInfo> attrsb = new List<AttributeInfo>();

            AttributeInfo attrb1 = new AttributeInfo();
            attrb1.Name = "Amazon Title";
            attrb1.Value = amazontitle.Text;
            attrsb.Add(attrb1);

            AttributeInfo attrb2 = new AttributeInfo();
            attrb2.Name = "Amazon Shipping Override";
            double sammy = Convert.ToDouble(amazonshippingoverride.Text);
            double sammy2 = sammy * totalAmount3;
            if (sammy2 < 455)
            {
                sammy2 = 455;
            }
            attrb2.Value = sammy2.ToString();
            attrsb.Add(attrb2);

            AttributeInfo attrb3 = new AttributeInfo();
            attrb3.Name = "Automatic Mode Price Output";
            double jimbo = Convert.ToDouble(automaticmodepriceoutput.Text);
            double jimbo2 = jimbo * totalAmount3;
            attrb3.Value = jimbo2.ToString();
            attrsb.Add(attrb3);

            AttributeInfo attrb4 = new AttributeInfo();
            attrb4.Name = "Buy Price";
            double ramjam = Convert.ToDouble(buyprice.Text);
            double ramjam2 = ramjam * totalAmount3;
            attrb4.Value = ramjam2.ToString();
            attrsb.Add(attrb4);

            AttributeInfo attrb5 = new AttributeInfo();
            attrb5.Name = "Buy Title";
            attrb5.Value = buytitle.Text;
            attrsb.Add(attrb5);

            AttributeInfo attrb6 = new AttributeInfo();
            attrb6.Name = "ceiling";
            double rosi = Convert.ToDouble(ceiling.Text);
            double rosi2 = rosi * totalAmount3;
            attrb6.Value = rosi2.ToString();
            attrsb.Add(attrb6);


            douche3.PriceInfo = new PriceInfo();
            douche3.PriceInfo.StartingPrice = shit3;
            douche3.ImageList = imgs.ToArray();
            douche3.AttributeList = attrsb.ToArray();

            APIResultOfBoolean okus = svc.SynchInventoryItem("afe6a7ba-dd0c-4292-827d-4385fba66ae2", douche);
            APIResultOfBoolean okuk = svc.SynchInventoryItem("c90abf9f-feae-40e7-b560-3eb97e104250", douche);
            APIResultOfBoolean okau = svc.SynchInventoryItem("4d779e61-a9d6-4e63-815d-fd7094b230a3", douche2);
            APIResultOfBoolean okjp = svc.SynchInventoryItem("4d09b782-35c2-458d-ba7f-d6a99dbf53ab", douche3);



            MessageBox.Show(String.Format("US - {0}", okus.Status.ToString() +"  " + String.Format("UK - {0}",okuk.Status.ToString() + "  " + String.Format("AU - {0}",okau.Status.ToString() + "  " + String.Format("JP - {0}", okjp.Status.ToString())))));


           

        }

       

       
    }
}

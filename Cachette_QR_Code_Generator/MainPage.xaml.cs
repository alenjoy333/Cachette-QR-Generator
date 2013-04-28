using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using com.google.zxing;
using com.google.zxing.qrcode;

namespace Cachette_QR_Code_Generator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void qrCodeGenerator(object sender, RoutedEventArgs e)
        {
            if (txtQRCode.Text != "")
            {
                lblError.Text = "";
                int qrWidth = 400;
                int qrHeight = 400;
                string qrCodeInput = txtQRCode.Text;
                QRCodeWriter generator = new QRCodeWriter();
                var qrMatrix = generator.encode(qrCodeInput, BarcodeFormat.QR_CODE, qrWidth, qrHeight);
                WriteableBitmap qrCodeImage = new System.Windows.Media.Imaging.WriteableBitmap(qrWidth, qrHeight);

                for (int y = 0; y < qrHeight; y++)
                {
                    for (int x = 0; x < qrWidth; x++)
                    {
                        int grayValue = qrMatrix.Array[y][x] & 0xff;
                        if (grayValue == 0)
                        {
                            qrCodeImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                        }
                        else
                        {
                            qrCodeImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                        }
                    }
                }
                imgQRCode.Source = qrCodeImage;
            }
            else
            {
                imgQRCode.Source = null;
                lblError.Text = "You Have To Enter A String To Generate QR Image";
               

            }
        }

    }
}
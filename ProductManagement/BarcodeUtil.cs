using Aspose.BarCode.Generation;
using System;

namespace ProductManagement
{
    public class BarcodeUtil
    {
        public static String GenerateNew(int a = 1000000, int b = 99999999)
        {
            var generator = new BarcodeGenerator(EncodeTypes.Code128, new Random().Next(a, b).ToString());

            return generator.CodeText;
        }
    }
}

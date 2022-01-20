using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ProductManagement
{
    public class DatabaseUtil
    {
        public static String DbConnection() {
            return $"{Properties.Settings.Default.connection_string}{DatabaseUtil.AttachedDbFilename()}";
        }

        private static String AttachedDbFilename() {
            var filePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

            return $"AttachDbFilename={filePath}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}Product.mdf";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class SampleExportAsImages
    {
        //public static void ExportCtlSaveAsImages()
        //{
        //    int count = 23;
        //    string[] passwords = new string[count];
        //    int[] encryptionType = new int[count];
        //    int[] frameCounts = { 9, 8, 7, 19, 41, 232, 277, 7, 5, 102, 35, 89, 2, 14, 1, 77, 1, 8, 15, 26, 24, 36, 30 };
        //    string[] fileNames = { @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot5395E97FB00000.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot5395EA6F870001.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot5396016035D0000.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot539608E260001.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot53960D922180002.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot53961243440003.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot539616045F0004.sdf",
        //    @"E:\input\snapshots\domain\VIRTCO\tara.osullivan\snapshot53E3BED82E60002.sdf",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_OGI5ZWNkNTliODM4YmZkZDUwZDExMDc1NjM4MGJj\2270358286120",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_MTc4NGY0OWE3OThiNWNiMmQzOThjMDRkOTk3NThh\22708392161100",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_MTc4NGY0OWE3OThiNWNiMmQzOThjMDRkOTk3NThh\22708392163640",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_MTc4NGY0OWE3OThiNWNiMmQzOThjMDRkOTk3NThh\22708392169570",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_MTc4NGY0OWE3OThiNWNiMmQzOThjMDRkOTk3NThh\22708392169820",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_NmU1OWRmMTQwMTY2NjU3NDIxYjdlNGNkZDRjMzNh\4602135212090",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZjM5YWU2Y2VkOTljOTI3MTVlM2I4M2JjOTk4MWE3\1422988233100",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZjM5YWU2Y2VkOTljOTI3MTVlM2I4M2JjOTk4MWE3\14229882332710",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZjM5YWU2Y2VkOTljOTI3MTVlM2I4M2JjOTk4MWE3\14229882332800",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\295819157190",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\2958191571410",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\2958191571920",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\29581915711610",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\29581915713120",
        //    @"E:\input\snapshots\virtco.pvt\VIRTCO - 7\SID_0.0.1.0_www.veriato.com_ZmExMGY0MzgxOTEyMmE0NWY2OTVlMjQwYzExMzAw\29581915713600"};

        //    int snapshotCount = 0;

        //    for (int i = 0; i < count; i++)
        //    {
        //        passwords[i] = "";
        //        encryptionType[i] = 0;
        //        snapshotCount += frameCounts[i];
        //    }

        //    ExportCtl2Lib.SpecExport2 specExport = new ExportCtl2Lib.SpecExport2();

        //    object objFiles = fileNames;
        //    object objPass = passwords;
        //    object objCounts = frameCounts;
        //    object objTypes = encryptionType;
        //    string tempPath = @"E:\output\Snapshots";

        //    specExport.ExportAsImages(ref objFiles, ref objTypes, ref objPass, ref objCounts, 1, tempPath);


        //    Console.WriteLine(snapshotCount + " are total no of snapshots.");
        //    Console.WriteLine("Exported All images ");
        //}


    }
}

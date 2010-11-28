﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Urasandesu.NAnonym.Cecil.DW
{
    public class DWConfigurationSection : ConfigurationSection
    {
        public static readonly string Name = typeof(DWConfigurationSection).Namespace + "/" + typeof(DWConfigurationSection).Name;

        [ConfigurationProperty("AssemblySetupSetPath", DefaultValue = "AssemblySetupSet.xml")]
        public string AssemblySetupSetPath
        {
            get { return (string)this["AssemblySetupSetPath"]; }
            set { this["AssemblySetupSetPath"] = value; }
        }

        [ConfigurationProperty("BackupDirectoryName", DefaultValue = "Backup")]
        public string BackupDirectoryName
        {
            get { return (string)this["BackupDirectoryName"]; }
            set { this["BackupDirectoryName"] = value; }
        }
    }
}
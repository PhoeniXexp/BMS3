using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BMS3
{
    public class ini
    {
        private static XmlDocument doc = new XmlDocument();
        private static string path;
        private static XmlNode windows;
        private static XmlNode skills;
        private static XmlNodeList windows_list;
        private static XmlNodeList skills_list;
        
        /// <summary>
        /// settings in ini file
        /// </summary>
        /// <param name="name">filename, default=bms</param>
        public ini(string name = "bms")
        {
            path = Environment.CurrentDirectory + "\\" + name + ".ini";

            if (File.Exists(path))
            {
                fileExist(path);
            }
            else
            {
                fileNotExist(path);
            }

        }

        private void fileExist(string path)
        {
            doc.Load(path);
        }

        private void fileNotExist(string path)
        {
            XmlElement root = doc.CreateElement("bms");
            doc.AppendChild(root);

            windows = doc.CreateElement("windows");
            root.AppendChild(windows);

            new_window("baff");
            new_window("hp");

            skills = doc.CreateElement("skills");
            root.AppendChild(skills);

            XmlNode skill = doc.CreateElement("skill");

            XmlAttribute attribute = doc.CreateAttribute("d");
            attribute.Value = "0";
            skill.Attributes.Append(attribute);
            skill.InnerText = "death";
            skills.AppendChild(skill);
        }

        /// <summary>
        /// Check window exist by name
        /// </summary>
        /// <param name="name">window name</param>        
        public static bool iswindow(string name)
        {
            XmlNode windows_node = doc.SelectSingleNode("//windows");
            windows_list = windows_node.SelectNodes("window");

            bool ret = false;

            foreach (XmlNode window in windows_list)
                if (window.InnerText == name)
                    ret = true;

            return ret;
        }

        public static bool isskill(string name)
        {
            XmlNode skills_node = doc.SelectSingleNode("//skills");
            skills_list = skills_node.SelectNodes("skill");

            bool ret = false;

            foreach (XmlNode skill in skills_list)
                if (skill.InnerText == name)
                    ret = true;

            return ret;
        }

        public static void save()
        {
            doc.Save(path);
        }

        /// <summary>
        /// create new windows in ini
        /// </summary>
        /// <param name="name">window name</param>
        public static void new_window(string name)
        {
            XmlNode window = doc.CreateElement("window");

            XmlAttribute attribute = doc.CreateAttribute("x0");
            attribute.Value = "200";
            window.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("y0");
            attribute.Value = "200";
            window.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("x");
            attribute.Value = "200";
            window.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("y");
            attribute.Value = "200";
            window.Attributes.Append(attribute);

            window.InnerText = name;
            windows.AppendChild(window);
        }

        /// <summary>
        /// save max chance of finded Name in area
        /// </summary>
        /// <param name="name">Skill's name</param>
        /// <param name="d">chance 10^4</param>
        public static void setskill(string name, double d)
        {
            if (!isskill(name)) return;

            foreach (XmlNode skill in skills_list)
            {
                if (skill.InnerText == name)
                {
                    try
                    {
                        if (getskill(name) < d)
                            skill.Attributes["d"].Value = Math.Round(d * 100000).ToString();
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// get max chance of find Name in area
        /// </summary>
        /// <param name="name">Skill's name</param>
        /// <returns></returns>
        public static double getskill(string name)
        {
            double ret = 0;
            if (!isskill(name)) return ret;

            foreach (XmlNode skill in skills_list)
            {
                if (skill.InnerText == name)
                {
                    try
                    {
                        var tmp = skill.Attributes["d"].Value;
                        ret = Convert.ToDouble(tmp) / 100000;
                        return ret;
                    }
                    catch { }
                }
            }
            return ret;
        }

        /// <summary>
        /// save params to ini
        /// </summary>
        /// <param name="name">window name</param>
        /// <param name="lu">Point Left-Up</param>
        /// <param name="x">Width</param>
        /// <param name="y">Height</param>
        public static void setparam(string name, System.Windows.Point lu, int x, int y)
        {
            if (!iswindow(name)) return;

            var x0 = (int)lu.X;
            var y0 = (int)lu.Y;

            foreach (XmlNode window in windows_list)
            {
                if (window.InnerText == name)
                {
                    try
                    {
                        window.Attributes["x0"].Value = x0.ToString();
                        window.Attributes["y0"].Value = y0.ToString();
                        window.Attributes["x"].Value = x.ToString();
                        window.Attributes["y"].Value = y.ToString();
                    }
                    catch { }
                }
            }
            save();
        }

        /// <summary>
        /// Load params from ini
        /// </summary>
        /// <param name="name">window name</param>
        /// <param name="lu">Point Left-Up</param>
        /// <param name="x">Width</param>
        /// <param name="y">Height</param>
        public static void getparam(string name, ref System.Windows.Point lu, ref int x, ref int y)
        {
            if (!iswindow(name)) return;

            foreach (XmlNode window in windows_list)
            {
                if (window.InnerText == name)
                    if (window.Attributes.Count == 4)
                    {
                        try
                        {
                            lu.X = Convert.ToInt32(window.Attributes["x0"].Value);
                            lu.Y = Convert.ToInt32(window.Attributes["y0"].Value);
                            x = Convert.ToInt32(window.Attributes["x"].Value);
                            y = Convert.ToInt32(window.Attributes["y"].Value);
                        }
                        catch { }
                    }
            }
        }
    }
}
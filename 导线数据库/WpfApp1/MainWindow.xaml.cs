using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml;
using Microsoft.Win32;

namespace WpfApp1
{
    //引用请标注出处-版权所属-李戴-2019.12
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private XElement xmlDoc;  //字段初始值无法引用非静态字段解决方法
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)  //选择xml文件位置
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //显示选择文件对话框      
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"; //xml或all的文件格式  
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == true)
            {
                this.textBox1.Text = openFileDialog1.FileName;   //显示文件路径   
            }
        }
        private void button5_Click(object sender, RoutedEventArgs e)  //输入关键字或完整Xpath查询导线参数
        {
            string filePath = this.textBox1.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode rootNode = doc.DocumentElement;  //提取根节点
            XmlNamespaceManager conductorDataBaseNamespaceManager = new XmlNamespaceManager(doc.NameTable);  //添加匹配命名空间
            conductorDataBaseNamespaceManager.AddNamespace("cDB", "conductorDataBase-2019.11.8-LiDai");
            if (radioButton1.IsChecked == true)
            {
                XmlNodeList childNodeList = rootNode.SelectNodes(this.textBox2.Text, conductorDataBaseNamespaceManager);  //输入完整Xpath查询根节点得满足条件的子节点列表
                foreach (XmlElement element in childNodeList)  //输出子节点列表中的每一项
                {
                    XmlNodeList childNode = element.ChildNodes;  //对当前子节点提取子节点的元素
                    string lv1 = childNode.Item(0).InnerText;
                    string lv2 = childNode.Item(1).InnerText;
                    string lv3 = childNode.Item(2).InnerText;
                    string lv4 = childNode.Item(3).InnerText;
                    string lv5 = childNode.Item(4).InnerText;
                    string lv6 = childNode.Item(5).InnerText;
                    string lv7 = childNode.Item(6).InnerText;
                    string lv8 = childNode.Item(7).InnerText;
                    string lv9 = childNode.Item(8).InnerText;
                    string lv10 = childNode.Item(9).InnerText;
                    this.listView1.BeginInit();  //数据更新，UI暂时挂起，直到EndInit绘制控件，可以有效避免闪烁并提高加载速度 
                    this.listView1.Items.Add(new conductorParameter{ 来源 = lv1, 型号 = lv2, 截面 = lv3, 外径 = lv4, 单位质量 = lv5, 额定拉断力 = lv6, 弹性系数 = lv7, 线膨胀系数 = lv8, 直流电阻 = lv9 });
                    this.listView1.EndInit();  //结束数据处理，UI界面一次性绘制。
                }
            }
            else
            {
                XmlNodeList childNodeList = rootNode.SelectNodes("cDB:导线[contains(cDB:型号,'" + this.textBox2.Text + "')]", conductorDataBaseNamespaceManager);  //型号关键字查询根节点得满足条件的子节点列表
                foreach (XmlElement element in childNodeList)  //输出子节点列表中的每一项
                {
                    XmlNodeList childNode = element.ChildNodes;  //对当前子节点提取子节点的元素
                    string lv1 = childNode.Item(0).InnerText;
                    string lv2 = childNode.Item(1).InnerText;
                    string lv3 = childNode.Item(2).InnerText;
                    string lv4 = childNode.Item(3).InnerText;
                    string lv5 = childNode.Item(4).InnerText;
                    string lv6 = childNode.Item(5).InnerText;
                    string lv7 = childNode.Item(6).InnerText;
                    string lv8 = childNode.Item(7).InnerText;
                    string lv9 = childNode.Item(8).InnerText;
                    string lv10 = childNode.Item(9).InnerText;
                    this.listView1.BeginInit();  //数据更新，UI暂时挂起，直到EndInit绘制控件，可以有效避免闪烁并提高加载速度 
                    this.listView1.Items.Add(new conductorParameter { 来源 = lv1, 型号 = lv2, 截面 = lv3, 外径 = lv4, 单位质量 = lv5, 额定拉断力 = lv6, 弹性系数 = lv7, 线膨胀系数 = lv8, 直流电阻 = lv9 });
                    this.listView1.EndInit();  //结束数据处理，UI界面一次性绘制。
                }
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)  //新增导线数据
        {
            Window1 w1 = new Window1();  //实例化Window1窗体w1
            w1.Show();
            w1.eventDelegate += new Window1.parameterDelegate(addConductor);  //调用w1的传递事件，对其绑定addConductor方法
        }
        public void addConductor(conductorParameter p)  //声明传递事件的方法
        {
            string[] xElementAddString = new string[10];  //传递参数保存至数组
            xElementAddString[0] = p.来源;
            xElementAddString[1] = p.型号;
            xElementAddString[2] = p.截面;
            xElementAddString[3] = p.外径;
            xElementAddString[4] = p.单位质量;
            xElementAddString[5] = p.额定拉断力;
            xElementAddString[6] = p.弹性系数;
            xElementAddString[7] = p.线膨胀系数;
            xElementAddString[8] = p.直流电阻;
            xElementAddString[9] = p.锁定;
            string filePath = textBox1.Text;
            XElement xmlDoc;
            xmlDoc = XElement.Load(filePath);
            XNamespace cDB = "conductorDataBase-2019.11.8-LiDai";  //为所有元素添加命名空间以去除xmlns=""
            XElement conductorElement = new XElement(cDB + "导线",
                                     new XElement(cDB + "来源", xElementAddString[0]),
                                     new XElement(cDB + "型号", xElementAddString[1]),
                                     new XElement(cDB + "截面mm2", xElementAddString[2]),
                                     new XElement(cDB + "外径mm", xElementAddString[3]),
                                     new XElement(cDB + "单位质量kg每m", xElementAddString[4]),
                                     new XElement(cDB + "额定拉断力N", xElementAddString[5]),
                                     new XElement(cDB + "弹性系数N每mm2", xElementAddString[6]),
                                     new XElement(cDB + "线膨胀系数每度", xElementAddString[7]),
                                     new XElement(cDB + "二十度直流电阻ohm每公里", xElementAddString[8]),
                                     new XElement(cDB + "锁定", xElementAddString[9])
                                                     );
            xmlDoc.Add(conductorElement);  //添加元素至xml
            xmlDoc.Save(filePath);
        }
        private void button7_Click(object sender, RoutedEventArgs e)  //移除listView1中选中行
        {
           for (int i = listView1.SelectedItems.Count - 1;i>= 0;i--)  //选中项倒序循环(foreach遍历选中项不能用于删除或修改)
            {
                listView1.Items.Remove(listView1.SelectedItems[i]);   //按项移除
            }
        }
        private void button6_Click(object sender, RoutedEventArgs e)  //清空listView1所有项
        {
            this.listView1.Items.Clear();  //移除所有项
        }
        private void button4_Click(object sender, RoutedEventArgs e)  //删除list中选中项对应的数据库内节点
        {
            string filePath = this.textBox1.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode rootNode = doc.DocumentElement;  //提取根节点
            XmlNamespaceManager conductorDataBaseNamespaceManager = new XmlNamespaceManager(doc.NameTable);  //添加匹配命名空间
            conductorDataBaseNamespaceManager.AddNamespace("cDB", "conductorDataBase-2019.11.8-LiDai");
            foreach (conductorParameter cP in listView1.SelectedItems)  //选中项遍历 
            {
                XmlNodeList deleteNodeList = rootNode.SelectNodes("cDB:导线[cDB:来源='" + cP.来源 + "' and cDB:型号='" + cP.型号 + "' and cDB:截面mm2='" + cP.截面 + "' and cDB:外径mm='" + cP.外径 + "' and cDB:单位质量kg每m='" + cP.单位质量 + "' and cDB:额定拉断力N='" + cP.额定拉断力 + "' and cDB:弹性系数N每mm2='" + cP.弹性系数 + "' and cDB:线膨胀系数每度='" + cP.线膨胀系数 + "' and cDB:二十度直流电阻ohm每公里='" + cP.直流电阻 + "']", conductorDataBaseNamespaceManager);  //查询根节点得满足9参数的待删除子节点列表
                foreach (XmlNode deleteNode in deleteNodeList)  //删除待删除子节点列表中的每一项
                {
                    XmlNode deleteParentNode = deleteNode.ParentNode;  //用XmlNode.RemoveChild(XmlNode)方法移除对应子节点
                    deleteParentNode.RemoveChild(deleteNode);
                }
            }
            doc.Save(filePath);
        }
        private void button3_Click(object sender, RoutedEventArgs e)  //修改列表选中项元素
        {
            string filePath = this.textBox1.Text;
            XmlDocument changeDoc = new XmlDocument();
            changeDoc.Load(filePath);
            string changeItem = comboBox1.Text;  //选择待修改参数
            XmlElement rootChangeElement = changeDoc.DocumentElement;  //根元素转根节点
            XmlNode rootChangeNode = rootChangeElement;
            foreach (conductorParameter cP in listView1.SelectedItems)  //选中项遍历 
            {
                foreach (XmlNode changeNode in rootChangeNode.ChildNodes)  //遍历根节点的子节点
                {
                    if (changeNode["来源"].InnerText == cP.来源 && changeNode["型号"].InnerText == cP.型号 && changeNode["截面mm2"].InnerText == cP.截面 && changeNode["外径mm"].InnerText == cP.外径 && changeNode["单位质量kg每m"].InnerText == cP.单位质量 && changeNode["额定拉断力N"].InnerText == cP.额定拉断力 && changeNode["弹性系数N每mm2"].InnerText == cP.弹性系数 && changeNode["线膨胀系数每度"].InnerText == cP.线膨胀系数 && changeNode["二十度直流电阻ohm每公里"].InnerText == cP.直流电阻)  //检验9参数，对具有特定内容的子节点进行修改
                    {
                        if (changeItem == "来源")  //因导线参数Xml元素命名与实际comboBox选项有出入，选用多层判断
                        {
                            changeNode["来源"].InnerText = textBox3.Text;  //修改下拉选中项的值
                        }
                        else
                        {
                            if (changeItem == "型号")
                            {
                                changeNode["型号"].InnerText = textBox3.Text;  //修改下拉选中项的值
                            }
                            else
                            {
                                if (changeItem == "截面mm^2")
                                {
                                    changeNode["截面mm2"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                }
                                else
                                {
                                    if (changeItem == "外径mm")
                                    {
                                        changeNode["外径mm"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                    }
                                    else
                                    {
                                        if (changeItem == "单位质量kg/m")
                                        {
                                            changeNode["单位质量kg每m"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                        }
                                        else
                                        {
                                            if (changeItem == "额定拉断力N")
                                            {
                                                changeNode["额定拉断力N"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                            }
                                            else
                                            {
                                                if (changeItem == "弹性系数N/mm^2")
                                                {
                                                    changeNode["弹性系数N每mm2"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                                }
                                                else
                                                {
                                                    if (changeItem == "线膨胀系数1/℃")
                                                    {
                                                        changeNode["线膨胀系数每度"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                                    }
                                                    else
                                                    {
                                                        if (changeItem == "20℃直流电阻Ω/km")
                                                        {
                                                            changeNode["二十度直流电阻ohm每公里"].InnerText = textBox3.Text;  //修改下拉选中项的值
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            changeDoc.Save(filePath);
        }
        bool boolCheck = false;
        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            if (boolCheck == true)
            {
                radioButton1.IsChecked = false;
                boolCheck = false;
            }
            else
            {
                radioButton1.IsChecked = true;
                boolCheck = true;
            }
        }
    }
    public class conductorParameter  //声明含内部参数的导线参数类
    {
        public string 来源 { get; set; }
        public string 型号 { get; set; }
        public string 截面 { get; set; }
        public string 外径 { get; set; }
        public string 单位质量 { get; set; }
        public string 额定拉断力 { get; set; }
        public string 弹性系数 { get; set; }
        public string 线膨胀系数 { get; set; }
        public string 直流电阻 { get; set; }
        public string 锁定 { get; set; }
    }
}

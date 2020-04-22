using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CADWPF.CADWPF
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class AddConductor : Window
    {
        public delegate void parameterDelegate(conductorParameter p);  //声明一个传递委托
        public event parameterDelegate eventDelegate;  //声明一个传递事件
        public AddConductor()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)  //赋值添加导线参数调用传递事件
        {
            conductorParameter p = new conductorParameter() { 来源 = textBox1.Text, 型号 = textBox2.Text, 截面 = textBox3.Text, 外径 = textBox4.Text, 单位质量 = textBox5.Text, 额定拉断力 = textBox6.Text, 弹性系数 = textBox7.Text, 线膨胀系数 = textBox8.Text, 直流电阻 = textBox9.Text, 锁定 = checkBox1.IsChecked.ToString() };  //textbox3-9内字符串转双精度，checkbox1内为布尔值
            eventDelegate(p);
            Close();
        }
    }
}

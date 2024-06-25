using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пр22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> userDictionary = new Dictionary<string, string>();

                string[] key = textBox1.Text.Split(' ');
                string[] volue = textBox2.Text.Split(' ');

                if (key.Length == volue.Length & key.Length == 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!String.IsNullOrEmpty(key[i].Trim()) && !String.IsNullOrEmpty(volue[i].Trim()))
                        {
                            userDictionary[key[i].Trim()] = volue[i].Trim();
                        }
                    }

                    // Меняем местами первый и последний элемент
                    //KeyValuePair<string, string> firstElement = userDictionary.ElementAt(0);
                    //KeyValuePair<string, string> lastElement = userDictionary.ElementAt(userDictionary.Count - 1);
                    //userDictionary[firstElement.Key] = lastElement.Value;
                    //userDictionary[lastElement.Key] = firstElement.Value;

                    KeyValuePair<string, string> firstElement = userDictionary.ElementAt(0);
                    KeyValuePair<string, string> lastElement = userDictionary.ElementAt(userDictionary.Count - 1);
                    userDictionary.Remove(firstElement.Key);
                    userDictionary.Remove(lastElement.Key);
                    userDictionary.Add(lastElement.Key, firstElement.Value);
                    userDictionary.Add(firstElement.Key, lastElement.Value);

                    // Удаляем второй элемент
                    userDictionary.Remove(userDictionary.ElementAt(1).Key);

                    //Добавляем пару в конец словаря
                    userDictionary.Add("new key", "new volue");

                    // Выводим словарь
                    foreach (KeyValuePair<string, string> item in userDictionary)
                    {
                        listBox1.Items.Add($"{item.Key}: {item.Value}");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте равны ли ваши данные 10!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}

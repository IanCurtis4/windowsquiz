using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace App2
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Question> Questions { get; set; }
        RadioButton TrueOption { get; set; }
        int Hits { get; set; }
        int Iterator { get; set; }

        public MainPage()
        {
            this.Hits = 0;
            this.Iterator = 1;
            this.InitializeComponent();
            Questions = new List<Question>()
            {
                new Question("Em que ano a América foi descoberta?", new List<Option>()
                {
                    new Option("1492", true),
                    new Option("1500", false),
                    new Option("1502", false)
                }),
                new Question("Quem é o baixista do Genesis?", new List<Option>()
                {
                    new Option("Mike Rutherford", true),
                    new Option("Peter Gabriel", false),
                    new Option("Steve Hackett", false)
                }),
                new Question("Qual o maior planeta do sistema solar?", new List<Option>()
                {
                    new Option("Júpiter", true),
                    new Option("Saturno", false),
                    new Option("Urano", false)
                })
            };

            List<RadioButton> radios = new List<RadioButton>() {
                firstOption, secondOption, thirdOption
            };

            int n = 2;
            int i = 0;

            do
            {
                int rnd = new Random().Next(n);
                radios[rnd].Content = Questions[0].Options[i].OptionText;
                radios[rnd].Tag = Questions[0].Options[i].Answer;
                radios.Remove(radios[rnd]);
                n--;
                i++;
            } while (n > 0);

            if ((bool) firstOption.Tag)
            {
                TrueOption = firstOption;
            }

            if ((bool) secondOption.Tag)
            {
                TrueOption = secondOption;
            }

            if ((bool) thirdOption.Tag)
            {
                TrueOption = thirdOption;
            }

            nextQuestion.Click += NextQuestion;
        }

        private void NextQuestion(object sender, RoutedEventArgs e) 
        {
            if (TrueOption.IsChecked ?? false)
            {

            }
        }       
    }

    public class Question
    {
        public List<Option> Options { get; set; }
        public string QuestionText { get; set; }

        public Question(string text, List<Option> options)
        {
            Options = options;
            QuestionText = text;
        }

        public Question()
        {
            Options = new List<Option>();
        }

    }

    public class Option
    {
        public string OptionText { get; set; }
        public bool Answer { get; set; }

        public Option(string text, bool hit)
        {
            OptionText = text;
            Answer = hit;
        }

        public Option()
        {

        }
    }
}

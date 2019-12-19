using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        List<RadioButton> radios { get; set; }

        public MainPage()
        {
            this.Hits = 0;
            this.Iterator = 0;
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
            nextQuestion.Content = "Próxima";
            
            PopulateLayoutObjects();
            GetTrueOption();
            nextQuestion.Click += NextQuestion;
            Iterator++;

        }

        private void NextQuestion(object sender, RoutedEventArgs e)
        {
            if (TrueOption.IsChecked ?? false)
            {
                Hits++;
            }

            if (Iterator < 3)
            {
                
                PopulateLayoutObjects();
                GetTrueOption();
                Iterator++;

            } else
            {
                result.Text = "Você acertou: " + Hits.ToString() + " vezes!";
                nextQuestion.IsEnabled = false;
            }
        }

        private void GetTrueOption()
        {
            if ((bool)firstOption.Tag)
            {
                TrueOption = firstOption;
            }

            if ((bool)secondOption.Tag)
            {
                TrueOption = secondOption;
            }

            if ((bool)thirdOption.Tag)
            {
                TrueOption = thirdOption;
            }
        }

        private void PopulateLayoutObjects()
        {
            questionText.Text = Questions[Iterator].QuestionText;

            radios = new List<RadioButton>() {
                firstOption, secondOption, thirdOption
            };

            int n = 3;
            int i = 0;
            Random rndGen = new Random();
            do
            {
                int rnd = rndGen.Next(n);
                radios[rnd].Content = Questions[Iterator].Options[i].OptionText;
                radios[rnd].Tag = Questions[Iterator].Options[i].Answer;
                radios.Remove(radios[rnd]);
                n--;
                i++;

            } while (n >= 1);
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

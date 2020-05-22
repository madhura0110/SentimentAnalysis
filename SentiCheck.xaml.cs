using System;
using System.Text;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SentimentAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Info
    {
        public string text { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AnalysisResult.Visibility = Visibility.Collapsed; //hiding the result textbox every time the API is called and before the result arrives
            if (AllEars.Text != null)
            {
                using var client = new HttpClient();

                Uri siteUri = new Uri("https://sentim-api.herokuapp.com/api/v1/"); //publicly available sentiment analysis API by Sharad Raj https://github.com/sharadcodes/

                var info = new Info
                {
                    text = AllEars.Text
                }; 

                var json = JsonConvert.SerializeObject(info); //converting the input text into Json Body
                var data = new StringContent(json, Encoding.UTF8, "application/json"); //building the HttpContent Object with the Request body

                var response = await client.PostAsync(siteUri, data); //storing the received HTTP response for the POST call made

                string respJson = response.Content.ReadAsStringAsync().Result; //store the response content as string so it can be parsed

                JObject o = JObject.Parse(respJson); //parsing response json content using Newtonsoft.Json namespace
                String sentiment = o.SelectToken("result.type").ToString(); //selects the token result.type to print the appropriate message
                AnalysisResult.Visibility = Visibility.Visible; //making the result textbox visible after the API response is received
                if (sentiment == "positive")
                {
                    AnalysisResult.Text = "Your thoughts seem positive today.\nI am happy for you.\nHave a good day!";
                }
                else if (sentiment == "negative")
                {
                    AnalysisResult.Text = "Your thoughts seem negative today.\nI suggest you seek help from a friend!";
                }
                else //neutral
                {
                    AnalysisResult.Text = "Your feelings seem neutral today. You can always talk to a friend to feel good.";
                }
            }
        }
    }
}
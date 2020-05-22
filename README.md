# SentimentAnalysis
<b>Sentiment Analysis of user input text</b>

This is a simple WPF .NetCore Application that uses XAML front end and C# as the backend/codebehind.

<b>Input</b>: User inputs the answer to "Hi, How are you feeling today?" in the WPF UI.

![Image description](https://github.com/madhura0110/SentimentAnalysis/blob/master/SentimentAnalysis/Input.PNG)

The application makes an HTTP POST request to a public Web API (https://sentim-api.herokuapp.com/) that provides sentiment analysis result.

<b>Output</b>: The Web API returns a JSON response, which the application then parses to determine the overall sentiment of the user input.

![Positive Sentiment](https://github.com/madhura0110/SentimentAnalysis/blob/master/SentimentAnalysis/Positive.PNG)

![Negative Sentiment](https://github.com/madhura0110/SentimentAnalysis/blob/master/SentimentAnalysis/Negative.PNG)

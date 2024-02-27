using HtmlAgilityPack;

using System.Text.RegularExpressions;

namespace DemyAI.Views;

public partial class JoinMeetingPage : ContentPage {

    private readonly JoinMeetingPageViewModel joinMeetingPageViewModel;

    public JoinMeetingPage(JoinMeetingPageViewModel joinMeetingPageViewModel) {
        InitializeComponent();
        this.joinMeetingPageViewModel = joinMeetingPageViewModel;
        BindingContext = this.joinMeetingPageViewModel;
    }

    private async void JoinWebView_Navigated(object sender, WebNavigatedEventArgs e) {

        await Task.Delay(2000);

        if(e.Result == WebNavigationResult.Success) {

            string script = "document.documentElement.outerHTML;";
            var res = await JoinWebView.EvaluateJavaScriptAsync(script);

            // Decode Unicode escape sequences
            string decodedHtml = DecodeUnicodeEscapeSequences(res);

            var parser = new HtmlDocument();

            // Load the decoded HTML into the HtmlDocument
            parser.LoadHtml(decodedHtml);

            // Hide the button using JavaScript by adding a style attribute
            await JoinWebView.EvaluateJavaScriptAsync("document.querySelector('.jsx-4281248356').style.display = 'none';");

            string createButtonScript = @"
                                            var button = document.createElement('button');
                                            button.textContent = 'Click Me';
                                            button.className = 'custom-button'; // Add a custom class for easier selection
                                            document.body.appendChild(button);
                                        ";

            // Execute the JavaScript code in the WebView to create the button
            await JoinWebView.EvaluateJavaScriptAsync(createButtonScript);

            // Now you can access both head and body
            HtmlNode bodyNode = parser.DocumentNode.SelectSingleNode("//body");

            if(bodyNode != null) {
                await Task.Delay(10000);
                bool answer;
                do {
                    answer = await DisplayAlert("Ready",
                        "Looks like everything is ready",
                        "Go to meeting",
                        "Wait");

                    if(answer) {
                        await JoinWebView.EvaluateJavaScriptAsync("document.querySelector('.jsx-4281248356').click();");
                        //await joinMeetingPageViewModel.UpdateMeetingData();
                    } else {
                        await Task.Delay(5000);
                    }
                } while(!answer);
            }
        }
    }
    // Function to decode Unicode escape sequences
    private static string DecodeUnicodeEscapeSequences(string input) {
        return Regex.Replace(input, @"\\u([0-9a-fA-F]{4})", match => ((char)Convert.ToInt32(match.Groups[1].Value, 16)).ToString());
    }
}


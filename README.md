# IP Messaging Quickstart for C# (ASP.NET MVC)

This application should give you a ready-made starting point for writing your
own messaging apps with Twilio IP Messaging. Before we begin, we need to collect
all the credentials we need to run the application:

Credential | Description
---------- | -----------
Twilio Account SID | Your main Twilio account identifier - [find it on your dashboard](https://www.twilio.com/user/account).
IP Messaging Service SID | Like a database ID for all your messaging app's data. Info on how to create one below.
API Key | Used to authenticate - [generate one here](https://www.twilio.com/user/account/messaging/dev-tools/api-keys).
API Secret | Used to authenticate - [just like the above, you'll get one here](https://www.twilio.com/user/account/messaging/dev-tools/api-keys).

## A Note on API Keys

When you generate an API key pair at the URLs above, your API Secret will only
be shown once - make sure to save this in a secure location, 
or possibly your system environment variables.

## Creating a Service SID

A service instance provides a shared scope for all the messages, users, and data
in our IP Messaging application. It's like a new database for all your app's data.

To create one, we can use the [REST API](/docs/api/ip-messaging/rest) - execute 
the following curl command in your terminal to create a service instance, whose 
SID you can use in your application. Replace `YourAppName` with an identifier
you would like to use, and `{api key}` and `{api secret}` with the values you
got from the step above.

```bash
curl -XPOST https://ip-messaging.twilio.com/v1/Services \
    -d "FriendlyName=YourAppName" \
    -u '{api key}:{api secret}'
```

Your new service SID will be prefixed with an `IS` in the JSON data you get back.

## Setting Up The Application

After downloading the repo, copy the `TwilioIpMessaging/Web.config.example` to
`Web.config` in the same directory. Next, open up `TwilioIpMessaging.sln` in
Visual Studio.  Edit `Web.config` with the four values we obtained above:

```xml
<appSettings>
	<add key="TwilioAccountSid" value="ACxxx" />
	<add key="TwilioApiKey" value="SKxxx" />
	<add key="TwilioApiSecret" value="xxxxxxxx" />
	<add key="TwilioIpmServiceSid" value="ISxxxx" />
</appSettings>
```

You should now be ready to rock! Hit `F5` or the Play button, and you should 
land on the home page of our basic chat application. Open it up in a few browser
tabs and start chatting with yourself!

![screenshot of chat app](https://s3.amazonaws.com/howtodocs/quickstart/ipm-browser-quickstart.png)

## License

MIT
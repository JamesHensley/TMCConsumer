# Traffic Message Channel Consumer
A simple dotnet core app to read TMC data from stdin, lookup event and location codes, and store the result in a flat file

The actual values for my EventList and LocationList have been purged to prevent any trouble with government entities

You'll need your own SDR and a way to pipe decoded message traffic to stdout

If you're using GNU Radio, you can use the below line for inspiration and load the "RDS-Rx-MsgOnly.grc" file from the GnuRadioMod folder (obviously you'll need to tweak it yourself):
<pre>python gnuradio-companion.py | C:\Programming\TMCConsumer\Consumer.exe "C:\Programming\TMCConsumer\EventList.txt" "C:\Programming\TMCConsumer\LocationList.txt" "C:\Programming\TMCConsumer\202012xxxxxxxx.json"</pre>
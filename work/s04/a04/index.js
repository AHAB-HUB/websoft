// here we have the server running on port 1337
var express = require('express');
var app = express();
var lotto = new require('./js/lotto');

app.set('view engine', 'ejs');

app.get('/report.html/', function(req, res) {
  res.sendFile(__dirname + '\\report.html');
});

app.get('/lotto', function(req, res) {

  try {
    var arr = req.query.row.split(',');
  } catch (error) {
    var arr = new Array(7);
  }
  res.render('lotto', {
    list: arr
  });
});

app.get('/lotto-json', function(req, res) {
  var list = lotto.rnd();
  var arr = req.query.row.split(',');
  var score = 0;

  for (var i = 0; i < list.length; i++) {
    if (list[i] == arr[i])
      score++;
  }
  var json = '{lottery:[' + list + '],user:[' + arr + '],score:' + score + '}';
  res.send(json);
});

app.get('/css/:dir', function(req, res) {
  res.sendFile(__dirname + '\\css\\' + req.params.dir);
});

app.get('/img/:dir', function(req, res) {
  res.sendFile(__dirname + '\\img\\' + req.params.dir);
});

app.get('/js/:dir', function(req, res) {
  res.sendFile(__dirname + '\\js\\' + req.params.dir);
});

// handling errors and none included files in this assignment
app.use(function(err, req, res, next) {
  res.sendFile(__dirname + '\\404.html');
});

app.get('*', function(req, res){
  res.sendFile(__dirname + '\\404.html');
});

app.listen(1337);

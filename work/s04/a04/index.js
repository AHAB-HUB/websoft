// here we have the server running on port 1337
var express = require('express');
var app = express();
var lotto = new require('./js/lotto');


app.set('view engine','ejs');
app.use('', express.static('a04'));

app.get('/report.html/', function(req, res){
    res.sendFile(__dirname + '\\report.html');
});

app.get('/lotto', function(req, res){
  var arr = req.query.row.split(',');
    res.render('lotto', {list: arr});//<%= person %>
});

app.get('/lotto-json', function(req, res){
    res.send(__dirname + '\\' + req.params.id + '.html');
});

app.get('/css/:dir', function(req, res){
  res.sendFile(__dirname +'\\css\\' + req.params.dir);
});

app.get('/img/:dir', function(req, res){
  res.sendFile(__dirname +'\\img\\' + req.params.dir);
});

app.get('/js/:dir', function(req, res){
  res.sendFile(__dirname +'\\js\\' + req.params.dir);
});

//handling errors and none included files in this assignment
// app.use(function(err, req, res, next) {
//   res.sendFile(__dirname + '\\404.html');
// });

// app.get('*', function(req, res){
//   res.sendFile(__dirname + '\\404.html');
// });

app.listen(1337);

const http = require('http');
const fs = require('fs');
const path = require('path');
const port = process.argv[2] || 3000;

http.createServer(function (req, res) {
  console.log(`${req.method} ${req.url}`);
  var filename = req.url === '/' ? '/index.html' : req.url;
  const ext = path.parse(filename).ext;
  // maps file extention to MIME typere
  const map = {
    '.ico': 'image/x-icon',
    '.html': 'text/html',
    '.js': 'text/javascript',
    '.json': 'application/json',
    '.css': 'text/css',
    '.png': 'image/png',
    '.jpg': 'image/jpeg',
    '.wav': 'audio/wav',
    '.mp3': 'audio/mpeg',
    '.svg': 'image/svg+xml',
    '.pdf': 'application/pdf',
    '.doc': 'application/msword'
  };

  fs.readFile(__dirname + filename, function (error, content) {
    if (error) {
      if (error.code == 'ENOENT') {
        res.writeHead(404);
        res.end();
      }
      else {
        res.writeHead(500);
        res.end('Sorry, check with the site admin for error: ' + error.code + ' ..\n');
        res.end();
      }
    }
    else {
      res.writeHead(200, { 'Content-Type': map[ext] });
      res.end(content, 'utf-8');
    }
  });

}).listen(parseInt(port));

console.log(`Server listening on port ${port}`);
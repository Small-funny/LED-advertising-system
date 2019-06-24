from flask import Flask, url_for, request, Response, jsonify
from functools import wraps
import os

app = Flask(__name__)

app.config['JSON_AS_ASCII'] = False

@app.route('/')
def test():
    return 'Hello world!'

@app.route('/getplaylist',endpoint='video')
def api_videolist():
    playlist = '';
    with open('C:/inetpub/wwwroot/upload_files/playlist.txt','r') as f:
        f.seek(0)
        playlist = f.read()
    return playlist

@app.route('/getpiclist',endpoint='pic')
def api_pic1():
    piclist = []
    with open('C:/inetpub/wwwroot/upload_files/piclist.txt','r') as f:
        f.seek(0)
        piclist = f.read().split(';')
    picdic = {}
    num = 1
    for i in piclist:
        picdic[str(num)] = i
        num += 1
  
    return jsonify(picdic)

if __name__ == '__main__':
    #app.run()
    app.run()


##Sample client for Tcpsocketlistener
## _P0W!

import socket

clientsocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
clientsocket.connect(('172.25.67.100', 12000)) ## Need to use default gateway of phone (  hotspot creator )
clientsocket.send('Default')

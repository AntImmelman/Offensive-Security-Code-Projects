#!/usr/bin/python3

import socket

temp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
temp.settimeout(7)

host_ip = input("Target IP: ")
port_number = int(input("Port you want to scan: "))

def portScanner(port_number)
  if temp.connect_ex((host_ip, port_number)):
    print("This port is CLOSED!")
  else:
    print("This port is OPEN!")
    
portScanner(port_number)

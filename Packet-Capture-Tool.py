import pcapy

info=pcapy.findallinfo()
inf=info[0]

captured = pcapy.open_live(inf, 65536, 1, 0)

count = 1
while count:
	(header, payload)=captured.next()
	print(count, "/n", header, "/n")
	print(payload, "\n\n")
	count+=1

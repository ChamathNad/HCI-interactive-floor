import socket
import asyncio
import websockets
import multiprocessing as mp

ip = '127.0.0.1'
port = 5500
q = mp.Queue()
x = y = 0


async def hello(websocket, path):
    global q
    while (True):
        try:
            name = await websocket.recv()
            print(f"< {name}")

            q.put(name)

            # greeting = f"Hello {name}!"

            # await websocket.send(greeting)
            # print(f"> {greeting}")
        except websockets.exceptions.ConnectionClosed:
            print('connection closed')
            return


def server(host, port, q):
      with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
          sock.bind((host, port))
          print("[+] Listening on {0}:{1}".format(host, port))
          sock.listen(1)
          conn, addr = sock.accept()

          with conn as c:
              print("[+] Connecting by {0}:{1}".format(addr[0], addr[1]))
    
              while True:

                  #x = y =  99
                  while q.empty() is not False:
                      #response = f"{x},{y}"
                      response = q.get()
                      #print(response)
                      c.sendall(response.encode('utf-8'))
        
    



if __name__ == "__main__":
    
    # server(ip, port)
    p = mp.Process(target=server, args=(ip, port, q))
    p.start()



    start_server = websockets.serve(hello, "localhost", 8765)
 
    print('server stared')
    asyncio.get_event_loop().run_until_complete(start_server)
    asyncio.get_event_loop().run_forever()

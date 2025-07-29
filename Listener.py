import redis

def handle_message(msg):
    print(f"🔔 Received: {msg['data'].decode()}")

r = redis.Redis(host='localhost', port=6379)
p = r.pubsub()
p.subscribe(**{"alarms": handle_message})

print("📡 Subscribed to 'alarms' channel. Waiting for events...")
for message in p.listen():
    if message['type'] == 'message':
        handle_message(message)
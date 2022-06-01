import sys
import os
import random
from PIL import Image

path = sys.argv[1]
img_name = sys.argv[2] + '.png'
save_path = os.path.join(path, img_name)
colors = ['red', 'blue', 'green', 'black', 'white', 'yellow', 'pink']

img = Image.new('RGB', (100, 100), color = random.choice(colors))
img.save(save_path)

# this where the repositories is pushed automatically and easily

# using pyautogui, time and urllib2 module
import pyautogui as gui
import requests
import time

# time out connection
timeoutt = 5
# url git repositories
url = 'https://github.com/norman-andrians/extreme-maze-3d'

print("auto push extreme maze 3d project repositories to github (connection needed)")

# get versien and update information
versi = float(input('version: '))
commit = str(input('update: '))

print("auto add, commit, push, fetch repositories to github main branch")
print("connecting to " + url)

# timeout while push
time.sleep(timeoutt)
print("")

# connected
try:
	response = requests.get(url, timeout=timeoutt)

	print("pushing extreme maze project to github")
	print("version : " + str(versi))
	print("update  : " + commit + "\n")

	print("=====================================")

	# auto write and press keyboard
	gui.write('git add .')
	gui.press('enter')

	# when its not change the project but change the specific file
	if versi == 0:
		gui.write('git commit -m "github, ' + commit + '"')
	else:
		gui.write('git commit -m ' + '"version: ' + str(versi) + ', ' + commit + '"')

	gui.press('enter')
	gui.write('git push -f extreme-maze main')
	gui.press('enter')

	# end
# no connected
except (requests.ConnectionError, requests.Timeout) as exception:
	print("error, can't connecting to " + url)
	print("error, can't push project, please check your internet connection")
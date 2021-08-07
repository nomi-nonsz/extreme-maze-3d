import pyautogui as gui

versi = float(input('version: '))
commit = str(input('commit name: '))

gui.write('git add .')
gui.press('enter')
gui.write('git commit -m ' + '"version: ' + str(versi) + ', ' + commit + '"')
gui.press('enter')
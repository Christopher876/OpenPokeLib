import os
import time
from selenium import webdriver
from selenium.common.exceptions import NoSuchElementException
import selenium
from webdriver_manager.firefox import GeckoDriverManager
import random

option = webdriver.FirefoxOptions()
option.add_argument("window-size=1280,800")
option.add_argument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36")

driver = webdriver.Firefox(executable_path='./geckodriver',options=option)
driver.get("https://bulbapedia.bulbagarden.net/wiki/Hariyama_(Pok%C3%A9mon)")

t = driver.find_element_by_xpath('/html/body/div[1]/div[2]/div/div[7]/div/div[1]/div[4]/table[2]/tbody/tr[2]/td/table/tbody/tr/td[1]/table/tbody/tr/td[1]/a/span/b')
print(t.get_attribute("value"))
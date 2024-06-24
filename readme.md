# RiderNavigator
RiderNavigator is a Wox plugin that allows you to quickly navigate to your Rider projects and solutions.  
![2024-06-22_18h52_19.png](2024-06-22_18h52_19.png)

# Usage 
- `rider` - List all Rider projects and solutions
- `rider <search>` - Filter Rider projects and solutions
- `rider sln <search>` - Open Rider project or solution

# Install
`wpm install RiderNavigator`  
![2024-06-22_18h54_53.png](2024-06-22_18h54_53.png)

# Troubleshooting
- If Rider is not installed in the default location, you can set your environment variable.  
![img.png](img.png)  
![img_1.png](img_1.png)
- If you encounter an EverythingException, please check if the Everything service is running. If you haven't installed it yet, you can download it from this [EveryThing](https://www.voidtools.com/).  
![img_2.png](img_2.png)

# References
- [EveryThingSharp](https://github.com/Riboe/EverythingSharp)
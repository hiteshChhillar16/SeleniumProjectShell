# SeleniumProjectShell

## Purpose of the Project
This is a shell project, which developers can use to create minor automation items using Selenium for Chrome browser.
This project comes with the basic funcationality where the users can run  either the bat file or a shell script from IntelliJ to perform the following action for their web application.

* Login to application

## About
We would have to create a Shell script to run the console application easily. That would also allow us to modify the parameters.There are two ways to use the automation

* Loading the user and environment information saved in the Excel file.
* Passing parameters in the Shell script.

## More Information

* ExcelData folder contains the the sample excel file with predefined parameters, we can change those values to fit our needs
* ShellScripts folder contains the sample shell script that would allow us to pass parameters with the need of using an ExcelFile

## Usage

Clone this repository in the folder location "C:\DEV". Then create a bat file, similar to what is saved in ShellScripts folder of the repository
Add parameters like username, password, and environment.

For example : SeleniumProjectShell pg#PageName un#Username pd#password env#EnvironmentRoot

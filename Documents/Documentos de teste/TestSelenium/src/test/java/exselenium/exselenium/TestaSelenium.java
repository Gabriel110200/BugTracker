package exselenium.exselenium;
import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

public class TestaGoogle {
	
	

	protected WebDriver driver;
	

	@BeforeClass
	public static void configuraDriver() {
		System.setProperty("webdriver.chrome.driver", "C:\\libs\\chromedriver.exe");
	}
	
    @Before
    public void createDriver() {  
    
		driver = new ChromeDriver();
        driver.get("https://www.google.com.br");
    }	

	@Test
	public void ValidateCpf() {
		try 
		{
			System.setProperty("webdriver.chrome.driver", "C:\\libs\\chromedriver\\chromedriver.exe");
			WebDriver driver = new ChromeDriver();
			
			driver.get("http://localhost:4200/register");
			
			WebElement cpf = driver.findElement(By.id("cpf")); 
			cpf.sendKeys("11111111"); 
			
			WebElement alert = driver.findElement(By.id("alert")); 
			
			if(alert.getText().contains("CPF Inválido"))
			{
				System.out.print("Sucesso");
			}
			
			driver.close();
		}
        catch(Exception ex)
		{
        	
        	fail();
		}
	}
	
	
	public void ValidateCNPJ()
	{
		System.setProperty("webdriver.chrome.driver", "C:\\libs\\chromedriver\\chromedriver.exe");
		WebDriver driver = new ChromeDriver();
		
		driver.get("http://localhost:4200/register");
		
		WebElement cpf = driver.findElement(By.id("cnpj")); 
		cpf.sendKeys("11111111"); 
		
		WebElement alert = driver.findElement(By.id("alert")); 
		
		if(alert.getText().contains("CNPJ Inválido"))
		{
			System.out.print("Sucesso");
		}
		
		driver.close();
	}
	
    @After
    public void quitDriver() {
       driver.quit();
    }
}

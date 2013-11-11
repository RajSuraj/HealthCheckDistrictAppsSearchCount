Feature: HealthCheck
    as a system administrator
    I want a version health check
    In order to know the Alteryx service is working

Background:
Given the alteryx service is running at "http://gallery.alteryx.com"

Scenario Outline:  Version check
   When   I invoke the GET at "api/status"
   Then I see the version binaryVersionsserviceLayer is <servicelayerversion> and binaryVersionscloud is <cloudversion>
   Examples: 
   | servicelayerversion | cloudversion |
   | 8.6.1.42414         | 8.6.0.42414  |
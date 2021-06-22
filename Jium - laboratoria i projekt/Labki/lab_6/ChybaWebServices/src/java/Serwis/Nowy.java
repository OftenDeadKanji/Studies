/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Serwis;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Kanjiklub
 */
@WebService(serviceName = "Nowy")
public class Nowy {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "operacja")
    public String operacja(@WebParam(name = "parametr") String parametr) {
        //TODO write your implementation code here:
        return parametr.toUpperCase();
    }
}

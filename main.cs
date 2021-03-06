using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {

// 2.
    var lista = new List<string[]>();
    foreach(var sor in File.ReadLines(@"EUcsatlakozas.txt", Encoding.GetEncoding("iso-8859-1"))) {
       lista.Add(sor.Trim().Split(';'));
    }

// 3.feladat: EU tagállamainak száma: ? db
    Console.WriteLine($"3. feladat: EU tagállamainak száma: {lista.Count} db");
    
// 4.feladat: 2007-ben ? ország csatlakozott.
    int darab = 0;
    foreach(var sor in lista){
        if ( sor[1].Substring(0,4) == "2007"){
            darab++;
        }
    }
    Console.WriteLine($"4. feladat: 2007-ben {darab} ország csatlakozott.");

// 5. feladat: Magyarország csatlakozásának dátuma:
    string cs_datum = "";
    foreach(var line in lista){
        if ( line[0] == "Magyarország" ){
            cs_datum = line[1];
        }
    }
    Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {cs_datum}");

// 6. feladat: Májusban ? csatlakozás.
    bool volt_majusban = false;
    string message = "";
    foreach(var line in lista){
        if ( line[1].Substring(5,2) == "05"){
        volt_majusban = true;
        }
    }
    message = (volt_majusban) ? "volt" : "nem volt";
    Console.WriteLine($"6. feladat: Májusban {message} csatlakozás.");

// 7. Utoljára csatlakozott tagállam 
    string  utolso_datum = "", utolso_orszag = "";
    foreach(var line in lista){
        string orszag = line[0];
        string datum  = line[1];
        int cmp = datum.CompareTo(utolso_datum);
        if ( cmp > 0 ){
            utolso_datum  = datum;
            utolso_orszag = orszag;
        }
    }
    Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {utolso_orszag}");

// 8. évenkénti statisztika

    var statisztika = new Dictionary<string, int>();
    foreach (var line in lista) {
        string ev = line[1].Substring(0,4);
        if (statisztika.ContainsKey(ev)) {
        statisztika[ev]++;
        } 
        else {
            statisztika.Add(ev, 1);
        }
    }
    Console.WriteLine($"8. feladat: Statisztika");
    foreach(var item in statisztika){
        Console.WriteLine($"        {item.Key} - {item.Value} ország");
    }
   }
}

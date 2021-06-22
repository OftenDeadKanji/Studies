package pl.polsl.lab.streams;

import java.io.*;
import java.util.*;

public class RhymingWords {

    public static void main(String[] args) {
        RhymingWords rhymingWords = new RhymingWords();
        rhymingWords.operate();
    }

    public void operate() {
        List<String> listOfWords = new ArrayList<>();
        try (BufferedReader in = new BufferedReader(
                new InputStreamReader(
                        new FileInputStream("words.txt")))) {
            String tmpWord;
            while ((tmpWord = in.readLine()) != null) {
                listOfWords.add(tmpWord);
            }
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }

        reverseWords(listOfWords);
        Collections.sort(listOfWords);
        reverseWords(listOfWords);

        for (String word : listOfWords) {
            System.out.println(word);
        }
    }

    private void reverseWords(List<String> list) {
        StringBuffer stringBuffer;
        for (int i = 0; i < list.size(); i++) {
            String word = list.get(i);
            stringBuffer = new StringBuffer(word);
            list.set(i, stringBuffer.reverse().toString());
        }

    }
}

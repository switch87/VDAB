   M S B A M L   `   `   `  ����?  ;Bars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BarsBars  5   	       Bars.BarWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   %customclr-namespace:Bars     5   	   -   5          � Title$  Werken met bars��5   	   $	��350��6!   $	��525��6.    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Bars.BarWindow   mijnRouteCtrlB   Command# Z 5      5	        5
   
   -   5           mijnRouteCtrlI# Z 5      5        5   
   -   5        $
 Save��5      6B     5   
   -   5        $
 Open��5      6C     5   
   -   5        $ Print��5      6D     5   
   -   5        $ PrintPreview��5      6M     5   
   -   5        $ Close��5      6D    J� InputBindings 5      �� 5   
   
 �� Key$ B��6    �� 	Modifiers$ Controlf�6    �� Command# Z 5      �� 5   
   $ I��6   $ Controlf�6   # Z 5      .��5      ]� .+�5   
   o� -	   5        $��MenuBalk��5      $��24��6   $	��Top=�6+   .@�5      m� $��_Bestand��6   .@�5      m� $��Openen��6   	 m� Command$
	 Open��6+   6<   m� 5      $��Opslaan��6   $
	 Save��6,   6=   m� 5      $��Afdrukvoorbeeld��6   $	 PrintPreview��64   6M   m� 5      $��Afdrukken...��6   $	 Print��61   6C   �� 5       6   m� 5!      $��	Afsluiten��6   $	 Close��6.   6@   5"      m� 5#      $��Editeren��6   .@�5$      m� $��Knippen��6   $		 Cut��6,   6<   m� 5%      $��	Kopiëren��6   $
	 Copy��6-   6>   m� 5&      $��Plakken��6   $	 Paste��6,   6>   5'      m� 5(      $��_Lettertype��6   .@�5)      m� -
   5        $��Fontjes��5)      $
��Font��6*   .@�5*      m� -   5        $��Courier��5*      $��Courier New��6.   
 m� IsCheckable
 . 6q   m� 5+      -   5        $��Arial��5+      $��Arial��6,   
 . 6i   m� 5,      -   5        $��Comic��5,      $��Comic Sans MS��6,   
 . 6q   5-      m� 5.      -   5        $��MenuVet��5.      $��_Vetdruk��6*   
 .  m� InputGestureText$ Ctrl+B��6e   6�   m� 5/      -   5        $��
MenuSchuin��5/      $��_Schuindruk��6-   
 . $ Ctrl+I��6n   6�   51      52      `� 53   
   $	��Top=�6   $��30��6+   .�54      c� -   5        $��BestandBalk��54      .@�55      �� $��Close��6   .��56      �� $��images/afsluiten.png��6    6@   57      �� 58      $
��Open��6   .��59      �� $��images/open.png��6    6;   5:      �� 5;      $
��Save��6   .��5<      �� $��images/save.png��6    6;   5=      �� 5>      $��PrintPreview��6   .��5?      �� $��images/preview.png��6    6>   5@      �� 5A      $��Print��6   .��5B      �� $��images/print.png��6    6<   5C      5D      c� 5E      -   5        $��EditeerBalk��5E      .@�5F      �� $	��Cut��6   .��5G      �� $��Images/cut.png��6   66   6>   �� 5H      $
��Copy��6   .��5I      �� $��Images/copy.png��6   67   5J      �� 5K      $��Paste��6   .��5L      �� $��Images/paste.png��6   68   5M      5N      c� 5O      -   5        $��LettertypeBalk��5O      .@�5P      d� -   5        $��	ButtonVet��5P      .��5Q      �� $��Images/bold.png��6   67   5R      d� 5S      -   5        $��ButtonSchuin��5S      .��5T      �� $��Images/italic.png��6   69   5U      �� 5V      -   5        $��LettertypeComboBox��5V      $	��150��65   ��5W      ��    System.Windows.Media.Fonts   SystemFontFamilies �� Source# Z ��5X      �� 5Y      .R�5Z      �� ��6(   �� ��6?   �� 5[      5]      5^      5_      �� 5a   
   $��Bottom=�6   $��24��6,   .@�5b      �� -   5        $��	StatusVet��5b      $��Right=�6-   $��50��6D   $��Right=�5c      ��5d      ��  �� ElementName$ TextBoxVoorbeeld�� �� Path$ 
FontWeight�.��6a   Vet6f   �� 5e      -   5        $��StatusSchuin��5e      $��Right=�60   $��50��6G   $��Right=�5f      ��5g      �� $ TextBoxVoorbeeld��$ 	FontStyle�.��6_   Schuin6g   �� 5h      -   5        $��StatusLettertype��5h      ��5i      �� $ LettertypeComboBox��$ SelectedValue�6e   5j      �� 5k   
   -   5        $��TextBoxVoorbeeld��5k      $��Dit is voorbeeldtext��6*   $��Stretch=�5l      $��Stretch=�6.   $��24(�5m       �� TextWrapping$
 Wrap=�6    $	��600��64   $	��900��6C   ��5n      �� $ LettertypeComboBox��$ SelectedValue�.��6[   5p      5q      5r      
   M S B A M L   `   `   `  ����B  >WPFGOL3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFGOL3WPFGOL3  5   	       WPFGOL3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFGOL3     5   	   -   5          �Name$  Main_Window��5   	    � Title$ Game of Life��5   	   $��Consolas)�5	   	   $��18(�5
   	    J� SnapsToDevicePixels .  � UseLayoutRounding .  � WindowStartupLocation$ CenterScreen=�5   	   $��5q�6/   $
��1440��6;   $	��900��6H   
�������.��5      � -   5        $��gridMain��5       � ShowGridLines .  $��10q�61    . }�.  � RowDefinitions 5   
   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   .+�51   
   �� -   5         ��Name$ 	Generator��51      $��0��6$   {�.  
���   �$��10,15q�6k   $��0,50,10,-50q�6{   $��Center=�6�   .��6�   
Generate6�   �� 52   
   -   5        $ Reset��52      $��0��6    
���   �$��10,15q�6V   $��0,150,10,-150q�6f   $��Center=�6}   .��6�   Reset6�   �� 53   
   -   5        $ AutoGenerator��53      $��0��6(   {�.  
���   �$��10,15q�6k   $��0,100,10,-100q�6{   $��Center=�6�   .��6�   	Automatic6�   �� 54   
   -   5        $ SavingPrivateRyan��54      $��0��6,   
���   �$��10,15q�6]   $��0,200,10,-200q�6m   $��Center=�6�   .��6�   Save6�   �� 55   
   -   5        $ LoadingButton��55      $��0��6(   
���   �$��10,15q�6\   $��0,250,10,-250q�6l   $��Center=�6�   .��6�   Load6�   �� 56   
   -   5        $ 
ExitButton��56      $��0��6%   
���   �$��10,15q�6]   $��0,400,10,-400q�6m   $��Center=�6�   .��6�   Exit6�   �� 57   
   -	   5        	 ��Name$	 Generations��57      $�� ��6%   $��0��60   $
��Left=�6@   $��Center=�6\   $��5q�6w   $
��Auto��6�   $��10,5,0,0q�6�   
 J� RenderTransformOrigin$
 	0.8,1.172&�6�   �� 58   
   -
   5        $	 
AliveCells��58      $�� ��6$   $
��Left=�6/   $
��Auto��6J   $��0��6W   $��Center=�6d   $��5q�6   $��180,5,-83,0q�6�   �� 59   
   -   5        $	 Speed��59      $
��Left=�6~   $��Center=�6�   $
��Auto��6�   $��5q�6�   $��1��6�   $��455,5,-314,0q�6�   ��6    ��  �� ElementName$ Speed_Slider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5:   
   -   5         ��Name$ Speed_Slider��5:       �� TickFrequency$ 10Q�6'    �� IsSnapToTickEnabled .  � Minimum$ 50Q�6U    � Maximum$	 300Q�6b   $
��Left=�6�   $��Center=�6  $��495,5,-504,0q�6&  $	��180��6<   � Value 6�   �� $ Speed�� �� Mode$ OneWay=�$ PropertyChanged=�6<  �� 5;   
   -   5        $	 Speed_Proper��5;      $��Delay:��6'   $
��Left=�68   $��Center=�6T   $
��Auto��6o   $��5q�6|   $��1��6�   $��387,5,-285,0q�6�   �� 5<   
   -   5        $ Rules��5<      $��0��6    
���   �$��10,15q�6V   $��0,300,10,-300q�6f   $��Rules��6}   $��Center=�6�   �� 5=   
   -   5        $ GridSet��5=      $��0��6"   
���   �$��10,15q�6]   $��0,350,10,-350q�6m   $��	Grid Size��6�   $��Center=�6�   �� 5>   
   -   5        $ Spinny��5>      $��0��6!   
���   �$��10,15q�6F   $��0,494,10,-492q�6V   $��Spinny��6m   $��Center=�6~   6�   5R      5W      
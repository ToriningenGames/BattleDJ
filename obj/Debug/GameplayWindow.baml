   M S B A M L   `   `   `  ����D  @ScorpCamp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ScorpCamp	ScorpCamp  5   	       ScorpCamp.GameplayWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ScorpCamp     5   	     � Title$  Master's Mischief��5   	   $	��680��6#   $
��1270��60    � 
ResizeMode$ NoResize=�6=   ��5	      �� 5
   
    �� ImageSource$ Library.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��571* �6   �� 5      $
��120* �6   �� 5      $
��573* �6   .+�5   
   �� -   5         ��Name$ PlayerNameLabel��5      $��Label��6)   $	��Top=�69   $��
205,10,0,0q�6Q   $��Center=�6e   $��26��6�   ���	#BF23F7976�   �� 5   
   -   5        $ EnemyNameLabel��5      $��Label��6(   $	��Top=�68   $��
244,10,5,0q�6P   $��Center=�6d   $��2��6�   $��26��6�   ���	#BF23F797 J� RenderTransformOrigin$ 0.475,-2.276&�6�   �� 5   
   -   5         ��Name$ PlayerImage��5      $
��Left=�6%   $	��220��6@   $��
9.8,10,0,0q�6M   $	��Top=�6a   $	��220��6y   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ -1Q�60   �� 5      	 �� AngleY$	 0Q�6$   
 �� AngleX$
 0Q�6/   �� 5       �� Angle$ 1.292Q�6&   T� 5      5      5      �� 5   
   -   5        $ 
EnemyImage��5      $��2��6$   $
��Left=�64   $	��220��6O   $��
9.8,10,0,0q�6\   $	��Top=�6p   $	��220��6�   �� 5   
   -   5        $ PlayerStatusLabel��5      $��Label��6+   $��
205,88,0,0q�6;   $	��Top=�6O   $��Center=�6g   $��26��6�   ���	#BF23F7976�   �� 5    
   -   5        $ EnemyStatusLabel��5       $��Label��6*   $��2��6:   $
��Left=�6J   $��
244,88,0,0q�6e   $	��Top=�6y   $ -0.529,-0.413&�6�   $��26��6�   $	��319��6�   ���	#BF23F797$��Center=�6�   �� 5!   
   -   5         ��Name$ PlayerCardsStackPanel��5!      $	��432��64   $��	0,208,8,0q�6A   $	��Top=�6T    �� Orientation$ 
Horizontal=�6l   �� 5"   
   -   5        $ EnemyCardsStackPanel��5"      $��2��63   $	��432��6C   $��	5,208,5,0q�6P   $	��Top=�6c   $	��563��6{   $ 
Horizontal=�6�   5$      5%      